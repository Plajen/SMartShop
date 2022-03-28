namespace SMartShop.Domain.Models
{
    public class EmailAddress : Entity
    {
        public string Email { get; set; }

        public EmailAddress(int id, string email, int createdBy)
        {
            Id = id;
            Email = email;
            CreatedBy = createdBy;
        }

        public EmailAddress() { }
    }
}
