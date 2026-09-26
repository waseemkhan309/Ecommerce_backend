namespace Ecommerce_backend.Models
{
    public class ProductRating : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid BuyerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;

        // Navigation properties
        public Product Product { get; set; } = null!;
        public Buyer Buyer { get; set; } = null!;
    }
}
