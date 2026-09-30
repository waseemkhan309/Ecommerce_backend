using Ecommerce_backend.DTOs.AuthDTOs;

namespace Ecommerce_backend.Services.AuthServices
{
    public interface IAuthServices
    {
        public Task BuyerRegisterService(BuyerRegisterRequestDto request);
        public Task<BuyerLoginResponseDto> BuyerLoginService(BuyerLoginRequest sellerUserLoginRequest);
    }
}
