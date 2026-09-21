namespace Ecommerce_backend.DTOs.AuthDTOs
{
    public class SellerUserLoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
