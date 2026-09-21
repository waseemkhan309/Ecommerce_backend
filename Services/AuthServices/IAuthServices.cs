using Ecommerce_backend.DTOs.AuthDTOs;

namespace Ecommerce_backend.Services.AuthServices
{
    public interface IAuthServices
    {
        public Task<RegisterUserResponseDto> RegisterSellerService(RegisterSellerRequestDto request);
        public Task<SellerUserLoginResponse> LoginSellerService(SellerUserLoginRequest sellerUserLoginRequest);
    }
}
