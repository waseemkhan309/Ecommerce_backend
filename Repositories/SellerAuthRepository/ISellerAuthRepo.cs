using Ecommerce_backend.DTOs.AuthDTOs.Seller;
using Ecommerce_backend.Models;

namespace Ecommerce_backend.Repositories.SellerAuthRepository
{
    public interface ISellerAuthRepo
    {
        Task<Guid> SellerRegisterRepo(SellerRegisterRequestDto request);
        Task<Seller> SellerGetByEmail(string email);
        Task<Seller> SellerGetById(Guid id);
        //Task<SellerLoginResponseDto> SellerLoginRepo(SellerLoginRequestDto request);
    }
}
