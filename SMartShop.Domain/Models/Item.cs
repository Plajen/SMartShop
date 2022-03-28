namespace SMartShop.Domain.Models
{
    public class Item : Entity
    {
        public int Quantity { get; set; }
        public decimal SubTotalPrice { get; set; }
        public int ProductId { get; set; }
        public int ShoppingCartId { get; set; }

        public Product Product { get; set; }
    }
}
