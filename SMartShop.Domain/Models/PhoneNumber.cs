using System.ComponentModel.DataAnnotations.Schema;

namespace SMartShop.Domain.Models
{
    public class PhoneNumber : Entity
    {
        public string Phone { get; set; }
        public int CustomerId { get; set; }
    }
}
