using Ecommerce_backend.DTOs.AuthDTOs;
using Ecommerce_backend.DTOs.TokenDto;
using Ecommerce_backend.Models;
using Ecommerce_backend.Repositories.AuthRepository;
using Ecommerce_backend.Services.PasswordHash;
using Ecommerce_backend.Services.TokenService;
using Ecommerce_backend.UnitOfWork.RegisterUserUOW;
using Ecommerce_backend.UnitOfWorks;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Ecommerce_backend.Services.AuthServices
{
    public class AuthServices(
              IPasswordHash passwordHash,
              IRegisterUserUOW registerUserUOW,
              IAuthRepository authRepository,
              ITokenService tokenService,
              IUnitOfWork unitOfWork
    ) : IAuthServices
    {

        private readonly IPasswordHash _passwordHash = passwordHash;
        private readonly IRegisterUserUOW _registerUserUOW = registerUserUOW;
        private readonly IAuthRepository _authRepository = authRepository;
        private readonly ITokenService _tokenServices = tokenService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;


        public async Task BuyerRegisterService(BuyerRegisterRequestDto buyerRegReqDto)
        {
            // check the password valud should not be null and then hashed it
            if (
                string.IsNullOrEmpty(buyerRegReqDto.Password) ||
                string.IsNullOrEmpty(buyerRegReqDto.Email) ||
                string.IsNullOrEmpty(buyerRegReqDto.UserName) ||
                string.IsNullOrEmpty(buyerRegReqDto.FirstName) ||
                string.IsNullOrEmpty(buyerRegReqDto.LastName) ||
                string.IsNullOrEmpty(buyerRegReqDto.PhoneNumber) ||
                string.IsNullOrEmpty(buyerRegReqDto.Country) ||
                string.IsNullOrEmpty(buyerRegReqDto.Gender) ||
                string.IsNullOrEmpty(buyerRegReqDto.Street) ||
                string.IsNullOrEmpty(buyerRegReqDto.City) ||
                string.IsNullOrEmpty(buyerRegReqDto.State) ||
                string.IsNullOrEmpty(buyerRegReqDto.PostalCode) ||
                string.IsNullOrEmpty(buyerRegReqDto.Area)
            )
            {
                throw new ArgumentException("Some fields contain empty or null values. Please review the form data.");
            }

            Buyer? buyerRecord = await _authRepository.GetUserByEmail(buyerRegReqDto.Email);
            if(buyerRecord is not null)
            {
                throw new InvalidOperationException("User already exist, please do login");
            }

            // Hash the password
            string hashedPassword = _passwordHash.HashPassword(buyerRegReqDto.Password);

            // Create a new RegisterUserResponseDto object with the hashed password
            var buyerObj = new Buyer
            {
                UserName = buyerRegReqDto.UserName,
                FirstName = buyerRegReqDto.FirstName,
                LastName = buyerRegReqDto.LastName,
                Email = buyerRegReqDto.Email,
                PhoneNumber = buyerRegReqDto.PhoneNumber,
                PasswordHash = hashedPassword,
                IsEmailVerified = false,
                IsPhoneNumberVerified = false,
                Country = buyerRegReqDto.Country,
                Gender = buyerRegReqDto.Gender,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var address = new Address
            {
                Street = buyerRegReqDto.Street,
                City = buyerRegReqDto.City,
                State = buyerRegReqDto.State,
                PostalCode = buyerRegReqDto.PostalCode,
                Country = buyerRegReqDto.Country,
                Area = buyerRegReqDto.Area,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _registerUserUOW.RegisterBuyerWithAddress(buyerObj, address);
            await _unitOfWork.SaveChangesAsync();
        }


        // login seller user
        public async Task<BuyerLoginResponseDto> BuyerLoginService(BuyerLoginRequest buyerLoginReq)
        {
            try
            {
                // find the user againts email from database
                Buyer? buyerRecord = await _authRepository.GetUserByEmail(buyerLoginReq.Email);

                // verify both existence AND password in one generic failure path
                if (buyerRecord is null || !_passwordHash.VerifyPassword(buyerLoginReq.Password, buyerRecord.PasswordHash))
                {
                    throw new UnauthorizedAccessException("Invalid email or password Or User doesn't exist.");
                }

                // if exist then create the token
                // PENDING TASK ---- make it generic later because generic for buyer and seller

                var userClaim = new UserClaim
                {
                    Id = buyerRecord.Id,
                    Username = buyerRecord.UserName,
                    Email = buyerRecord.Email,
                    Role = "Buyer"
                };

                var accessTokenString =  _tokenServices.CreateAccessToken(userClaim);

                // return token
                return new BuyerLoginResponseDto
                {
                    FirstName = buyerRecord.FirstName,
                    LastName = buyerRecord.LastName,
                    Email = buyerRecord.Email,
                    UserName = buyerRecord.UserName,
                    AccessToken = accessTokenString
                };


            }catch(Exception )
            {
                throw;
            }
        }

      
    }
}
