namespace Ecommerce_backend.DTOs.AuthDTOs
{
    public class BuyerRegisterResponseDto
    {
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsEmailVerified { get; set; } = false;
        public bool IsPhoneNumberVerified { get; set; } = false;
        public string Country { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
    }
}
