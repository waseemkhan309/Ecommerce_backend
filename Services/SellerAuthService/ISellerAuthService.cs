using Ecommerce_backend.DTOs.AuthDTOs;
using Ecommerce_backend.DTOs.AuthDTOs.Seller;

namespace Ecommerce_backend.Services.SellerAuthService
{
    public interface ISellerAuthService
    {
        Task<Guid> SellerRegisterService(SellerRegisterRequestDto request);
        public Task<SellerLoginResponseDto> SellerLoginService(SellerLoginRequestDto sellerLoginRequest);
    }
}   
