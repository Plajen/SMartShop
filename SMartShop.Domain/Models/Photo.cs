using System.ComponentModel.DataAnnotations.Schema;

namespace SMartShop.Domain.Models
{
    public class Photo : Entity
    {
        public byte[] Bytes { get; set; }
        public string Name { get; set; }
        public string FileExtension { get; set; }
        public decimal Size { get; set; }
        public int ProductId { get; set; }
    }
}
