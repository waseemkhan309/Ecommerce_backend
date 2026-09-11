namespace Ecommerce_backend.Models
{
    public class Comment : BaseEntity
    {
        public int ProductId { get; set; }
        public int BuyerId { get; set; }
        public string Content { get; set; } = string.Empty;
        // Navigation properties
        public Product Product { get; set; } = null!;
        public Buyer Buyer { get; set; } = null!;                           
    }
}
