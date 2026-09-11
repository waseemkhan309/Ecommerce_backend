namespace Ecommerce_backend.Models
{
    public class ProductImages : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();
        public string ImageUrl { get; set; } = string.Empty;
    }
}
