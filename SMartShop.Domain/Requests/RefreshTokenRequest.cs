namespace SMartShop.Domain.Requests
{
    public class RefreshTokenRequest
    {
        public string ExpiredToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
