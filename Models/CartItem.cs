
namespace Ecommerce_backend.Models
{
    public class CartItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = new Product();
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
 