namespace Ecommerce_backend.Models
{
    public class WishlistItem : BaseEntity
    {
        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; } = new Wishlist();
        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();
    }
}
