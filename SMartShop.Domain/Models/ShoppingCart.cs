using System.Collections.Generic;

namespace SMartShop.Domain.Models
{
    public class ShoppingCart : Entity
    {
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public virtual IEnumerable<Item> Items { get; set; }
    }
}
