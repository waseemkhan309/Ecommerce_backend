namespace Ecommerce_backend.Models
{
    public class Address : BaseEntity
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public Guid? BuyerId { get; set; }
        public Buyer? Buyer { get; set; }

        public Guid? SellerId { get; set; }
        public Seller? Seller { get; set; }
    }
}
