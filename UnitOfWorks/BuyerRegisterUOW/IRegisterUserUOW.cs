using Ecommerce_backend.Models;

namespace Ecommerce_backend.UnitOfWork.RegisterUserUOW
{
    public interface IRegisterUserUOW
    {
        Task RegisterBuyerWithAddress(Buyer buyer, Address address);
    }
}
