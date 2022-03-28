using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SMartShop.Domain.Models;
using SMartShop.Domain.Requests;
using SMartShop.Domain.Responses;
using SMartShop.Infra.CrossCutting.Infrastructure.Interfaces;
using SMartShop.Infra.CrossCutting.Infrastructure.Security;
using SMartShop.Infra.Interfaces;
using SMartShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SMartShop.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IOptions<JwtSettings> _config;
        private readonly ICrypto _crypto;

        private const string LOGIN_PRECISA_USUARIO_SENHA = "Informe usuário e senha para realizar o login";
        private const string CREDENCIAIS_INCORRETAS = "Nome de usuário ou senha incorretos";
        private const string TOKEN_INVALIDO = "Token inválido para renovação";

        public AuthService(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, 
            IOptions<JwtSettings> config, ICrypto crypto)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _config = config;
            _crypto = crypto;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.Username) && !string.IsNullOrWhiteSpace(request.Password))
            {
                var user = (await _userRepository.Read(username: request.Username)).EntityResult.SingleOrDefault();

                if (user == null)
                    return new LoginResponse(CREDENCIAIS_INCORRETAS);

                if (_crypto.Decrypt(user.Password, user.Salt) != request.Password)
                    return new LoginResponse(CREDENCIAIS_INCORRETAS);

                var refreshToken = new RefreshToken(GenerateRefreshToken(), user.Id);
                await SaveRefreshToken(refreshToken);
                return new LoginResponse(GenerateToken(user, null), refreshToken.Token);
            }

            return new LoginResponse(LOGIN_PRECISA_USUARIO_SENHA);
        }

        public async Task<LoginResponse> RefreshToken(RefreshTokenRequest request)
        {
            var principal = GetPrincipalFromExpiredToken(request.ExpiredToken).Identity as ClaimsIdentity;
            var userHasId = int.TryParse(principal.Claims.ToArray()[0].Value, out int userId);
            if (!userHasId)
                return new LoginResponse(TOKEN_INVALIDO);

            var savedRefreshToken = (await GetRefreshToken(userId)).EntityResult.SingleOrDefault();
            if (savedRefreshToken == null || savedRefreshToken.Token != request.RefreshToken)
                return new LoginResponse(TOKEN_INVALIDO);

            var newJwtToken = GenerateToken(null, principal.Claims);
            var newRefreshToken = new RefreshToken(GenerateRefreshToken(), userId);
            await DeleteRefreshToken(userId);
            await SaveRefreshToken(newRefreshToken);

            return new LoginResponse(newJwtToken, newRefreshToken.Token);
        }

        private string GenerateToken(User user, IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.Value.SecurityKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims != null && claims.Any() ? new ClaimsIdentity(claims) 
                : new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.NormalizedName),
                }),
                Expires = DateTime.UtcNow.AddMinutes(_config.Value.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.SecurityKey)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        private static string GenerateRefreshToken()
        {
            var randomKey = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomKey);
            return Convert.ToBase64String(randomKey);
        }

        private async Task<InternalResponse<RefreshToken>> SaveRefreshToken(RefreshToken refreshToken)
            => await _refreshTokenRepository.Create(refreshToken);

        private async Task<InternalResponse<RefreshToken>> GetRefreshToken(int userId)
            => await _refreshTokenRepository.Read(userId);

        private async Task<InternalResponse<RefreshToken>> DeleteRefreshToken(int userId)
            => await _refreshTokenRepository.Delete(userId);
    }
}
