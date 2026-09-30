using Ecommerce_backend.DTOs.TokenDto;
using Ecommerce_backend.Models;

namespace Ecommerce_backend.Services.TokenService
{
    public interface ITokenService
    {
        string CreateAccessToken(UserClaim userClaim);
    }
}
