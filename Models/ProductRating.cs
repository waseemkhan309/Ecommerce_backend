namespace Ecommerce_backend.Models
{
    public class ProductRating : BaseEntity
    {
        public int ProductId { get; set; }
        public int BuyerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;

        // Navigation properties
        public Product Product { get; set; } = null!;
        public Buyer Buyer { get; set; } = null!;
    }
}
