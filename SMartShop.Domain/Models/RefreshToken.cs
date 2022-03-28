namespace SMartShop.Domain.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }

        public RefreshToken(string token, int userId)
        {
            Token = token;
            UserId = userId;
        }

        public RefreshToken() { }

    }
}
