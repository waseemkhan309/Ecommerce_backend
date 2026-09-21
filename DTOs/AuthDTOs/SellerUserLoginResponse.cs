namespace Ecommerce_backend.DTOs.AuthDTOs
{
    public class SellerUserLoginResponse
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string AccessToken { get; set; } = string.Empty;
    }
}
