using SMartShop.Domain.Requests;
using SMartShop.Domain.Responses;
using System.Threading.Tasks;

namespace SMartShop.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<LoginResponse> RefreshToken(RefreshTokenRequest request);
    }
}
