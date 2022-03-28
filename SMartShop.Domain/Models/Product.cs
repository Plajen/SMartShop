using System;
using System.Collections.Generic;

namespace SMartShop.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public IEnumerable<Photo> Photos { get; set; }

        public Product(int id, string name, string description, decimal price, DateTime createdAt, int createdBy)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
        }

        public Product() { }
    }
}
