using Ecommerce_backend.DTOs.AuthDTOs.Seller;
using Ecommerce_backend.DTOs.TokenDto;
using Ecommerce_backend.Models;
using Ecommerce_backend.Repositories.AddressRepository;
using Ecommerce_backend.Repositories.OrganizationRepository;
using Ecommerce_backend.Repositories.SellerAuthRepository;
using Ecommerce_backend.Services.PasswordHash;
using Ecommerce_backend.Services.TokenService;
using Ecommerce_backend.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using System.Data.Common;

namespace Ecommerce_backend.Services.SellerAuthService
{
    public class SellerAuthService(
        ISellerAuthRepo sellerAuthRepo,
        IAddressRepository addressRepository,
        IOrganizationRepository organizationRepository,
        ITokenService tokenServices,
        IUnitOfWork unitOfWork,
        IPasswordHash passwordHash
        ) : ISellerAuthService
    {

        private readonly ISellerAuthRepo _sellerAuthRepo = sellerAuthRepo;
        private readonly IAddressRepository _addressRepository = addressRepository;
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ITokenService _tokenServices = tokenServices;
        private readonly IPasswordHash _passwordHash = passwordHash;


        public async Task<Guid> SellerRegisterService(SellerRegisterRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            // check if the seller already exists
            var existingSeller = await _sellerAuthRepo.SellerGetByEmail(request.Email);
            if (existingSeller != null)
            {
                throw new InvalidOperationException("Seller with the same email already exists.");
            }

            var dateTime = DateTime.UtcNow;

            // seller details
            var seller = new Seller
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Gender = request.Gender,
                Country = request.Country,
                CreatedAt = dateTime,
                UpdatedAt = dateTime

            };

            // seller address details
            var sellerAddressDetails = new Address
            {
                Street = request.Street,
                City = request.City,
                State = request.State,
                PostalCode = request.PostalCode,
                Area = request.Area,
                Country = request.Country,
                
                CreatedAt = dateTime,
                UpdatedAt = dateTime,

                Seller = seller
            };

            // seller organization details
            var sellerOrganizationDetails = new Organization
            {
                Name = request.Name,
                Description = request.Description,
                OrganizationURL = request.OrganizationURL,
                
                CreatedAt = dateTime,
                UpdatedAt = dateTime,

                Seller = seller
            };
            // seller organization address details
            var sellerOrganizationAddressDetails = new OrganizationAddress
            {
                OrgAddress = request.Area,
                OrgCity = request.City,
                OrgState = request.State,
                OrgCountry = request.Country,
                CreatedAt = dateTime,
                UpdatedAt = dateTime,

                Organization = sellerOrganizationDetails

            };

            await _addressRepository.AddUserAddress(sellerAddressDetails);
            await _organizationRepository.SellerOrganization(sellerOrganizationDetails);
            await _organizationRepository.SellerOrganizationAddress(sellerOrganizationAddressDetails);
            

            try
            {
                await _sellerAuthRepo.SellerRegisterRepo(seller);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine( ex.InnerException?.Message);
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Entries);
                throw;
            }

            return seller.Id;

        }



        // login seller user
        public async Task<SellerLoginResponseDto> SellerLoginService(SellerLoginRequestDto sellerReq)
        {

            if (string.IsNullOrEmpty(sellerReq.Email) || string.IsNullOrEmpty(sellerReq.Password))
            {
                throw new ArgumentException("Email and password cannot be null or empty.");
            }

            var seller = await _sellerAuthRepo.SellerGetByEmail(sellerReq.Email);

            // Verify the password
            if (seller is null || !_passwordHash.VerifyPassword(sellerReq.Password , seller.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid email or password Or User doesn't exist.");
            }


            var userClaim = new UserClaim
            {
                Id = seller.Id,
                Email = seller.Email,
                Username = seller.UserName,
                Role = "Seller"
            };


            var accessTokenString = _tokenServices.CreateAccessToken(userClaim);


            // Create login response
            var loginResponse = new SellerLoginResponseDto
            {
                UserName = seller.UserName,
                Email = seller.Email,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                AccessToken = accessTokenString
            };

            return loginResponse;

        }
    }
}
