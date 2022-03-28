namespace SMartShop.Infra.CrossCutting.Infrastructure.Security
{
    public class JwtSettings
    {
        public string SecurityKey { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
