namespace SMartShop.Domain.Models
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public User (int id, string login, string password, string salt, int roleId)
        {
            Id = id;
            Username = login;
            Password = password;
            Salt = salt;
            RoleId = roleId;
        }

        public User() { }
    }
}
