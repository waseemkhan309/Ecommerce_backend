using Ecommerce_backend.Repositories.CommentRepository;

namespace Ecommerce_backend.UnitOfWorks
{
    public interface IUnitOfWork
    {
       IComRepository Comments { get; }

       Task<int> SaveChangesAsync();
    }
}
