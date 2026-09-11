namespace Ecommerce_backend.Models
{
    public class Wishlist : BaseEntity
    {

        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; } = new Buyer();
    }
}
