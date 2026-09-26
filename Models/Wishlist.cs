namespace Ecommerce_backend.Models
{
    public class Wishlist : BaseEntity
    {
        public Guid BuyerId { get; set; }
        public Buyer Buyer { get; set; } = new Buyer();
    }
}


