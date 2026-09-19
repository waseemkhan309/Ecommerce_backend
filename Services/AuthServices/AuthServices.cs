using Ecommerce_backend.DTOs.AuthDTOs;
using Ecommerce_backend.Models;
using Ecommerce_backend.Services.PasswordHash;
using Ecommerce_backend.UnitOfWork.RegisterUserUOW;


namespace Ecommerce_backend.Services.AuthServices
{
    public class AuthServices(
              IPasswordHash passwordHash,
              IRegisterUserUOW registerUserUOW
    ) : IAuthServices
    {

        private IPasswordHash _passwordHash = passwordHash;
        private readonly IRegisterUserUOW _registerUserUOW = registerUserUOW;

        public async Task<RegisterUserResponseDto> RegisterSellerService(RegisterSellerRequestDto sellerRequest)
        {
            // check the password valud should not be null and then hashed it
            if (
                string.IsNullOrEmpty(sellerRequest.Password) ||
                string.IsNullOrEmpty(sellerRequest.Email) ||
                string.IsNullOrEmpty(sellerRequest.UserName) ||
                string.IsNullOrEmpty(sellerRequest.FirstName) ||
                string.IsNullOrEmpty(sellerRequest.LastName) ||
                string.IsNullOrEmpty(sellerRequest.PhoneNumber) ||
                string.IsNullOrEmpty(sellerRequest.Country) ||
                string.IsNullOrEmpty(sellerRequest.Gender) ||
                string.IsNullOrEmpty(sellerRequest.Street) ||
                string.IsNullOrEmpty(sellerRequest.City) ||
                string.IsNullOrEmpty(sellerRequest.State) ||
                string.IsNullOrEmpty(sellerRequest.PostalCode) ||
                string.IsNullOrEmpty(sellerRequest.Area)
            )
            {
                throw new ArgumentException("Some fields contain empty or null values. Please review the form data.");
            }



            // Hash the password
            string hashedPassword = _passwordHash.HashPassword(sellerRequest.Password);

            // Create a new RegisterUserResponseDto object with the hashed password
            var seller = new Seller
            {
                UserName = sellerRequest.UserName,
                FirstName = sellerRequest.FirstName,
                LastName = sellerRequest.LastName,
                Email = sellerRequest.Email,
                PhoneNumber = sellerRequest.PhoneNumber,
                PasswordHash = hashedPassword,
                IsEmailVerified = false,
                IsPhoneNumberVerified = false,
                Country = sellerRequest.Country,
                Gender = sellerRequest.Gender,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var address = new Address
            {
                Street = sellerRequest.Street,
                City = sellerRequest.City,
                State = sellerRequest.State,
                PostalCode = sellerRequest.PostalCode,
                Country = sellerRequest.Country,
                Area = sellerRequest.Area,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var registeredSeller = await _registerUserUOW.RegisterUserAndAddress(seller, address);

            return new RegisterUserResponseDto
            {
               UserName = registeredSeller.UserName,
               FirstName = registeredSeller.FirstName,
               LastName = registeredSeller.LastName,
               Email = registeredSeller.Email,
               Country = registeredSeller.Country,
               Gender = registeredSeller.Gender,
               PhoneNumber = registeredSeller.PhoneNumber,
            };

        }
    }
}
