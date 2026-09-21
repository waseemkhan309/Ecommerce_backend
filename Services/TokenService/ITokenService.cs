using Ecommerce_backend.Models;

namespace Ecommerce_backend.Services.TokenService
{
    public interface ITokenService
    {
        string CreateAccessToken(Seller seller);
    }
}
