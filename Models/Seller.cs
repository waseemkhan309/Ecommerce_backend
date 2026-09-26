namespace Ecommerce_backend.Models
{
    public class Seller : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsEmailVerified { get; set; } = false;
        public bool IsPhoneNumberVerified { get; set; } = false;
        public string PasswordHash { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
