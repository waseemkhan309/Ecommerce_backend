namespace Ecommerce_backend.Models
{
    public class Cart : BaseEntity
    {
        public int UserId { get; set; }
        public Buyer Buyer { get; set; } = new Buyer();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
