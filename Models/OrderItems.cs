namespace Ecommerce_backend.Models
{
    public class OrderItems : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = new Order();
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = new Product();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
