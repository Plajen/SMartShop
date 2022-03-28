using System;
using System.Collections.Generic;

namespace SMartShop.Domain.Models
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => GetFullName();
        public DateTime DateOfBirth { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public int EmailId {get; set; }

        public Address Address { get; set; }
        public User User { get; set; }
        public EmailAddress Email { get; set; }
        public virtual IEnumerable<PhoneNumber> Phones { get; set; }

        public Customer(int id, string firstName, string lastName, DateTime dateOfBirth, int addressId,
            int userId, int emailId, int createdBy)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            AddressId = addressId;
            UserId = userId;
            EmailId = emailId;
            CreatedBy = createdBy;
        }

        public Customer() { }

        private string GetFullName()
        {
            var names = new List<string> { FirstName, MiddleName, LastName };
            return string.Join(' ', names);
        }
    }
}
