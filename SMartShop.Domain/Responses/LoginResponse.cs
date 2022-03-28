using System.Collections.Generic;

namespace SMartShop.Domain.Responses
{
    public class LoginResponse
    {
        public string Token { get; private set; }
        public string RefreshToken { get; private set; }
        public List<string> Errors { get; private set; } = new List<string>();
        public bool Success { get; set; } = true;

        public LoginResponse(string error)
        {
            Success = false;
            Errors.Add(error);
        }

        public LoginResponse(string token, string refreshToken)
        {
            Success = true;
            Token = token;
            RefreshToken = refreshToken;
        }
    }
}
