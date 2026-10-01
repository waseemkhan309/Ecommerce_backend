using Ecommerce_backend.Repositories.CommentRepository;

namespace Ecommerce_backend.UnitOfWorks
{
    public interface IUnitOfWork
    {
       Task<int> SaveChangesAsync();
    }
}
