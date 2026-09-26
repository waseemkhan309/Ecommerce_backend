
namespace Ecommerce_backend.Models
{
    public class WishlistItem : BaseEntity
    {
        public Guid WishlistId { get; set; }
        public Wishlist Wishlist { get; set; } = new Wishlist();
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = new Product();
    }
}
