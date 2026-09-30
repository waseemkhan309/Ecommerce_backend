using Ecommerce_backend.Data;
using Ecommerce_backend.Repositories.CommentRepository;

namespace Ecommerce_backend.UnitOfWorks
{
    public class UnitOfWorkService(
        ApplicationDbContext dbContext,
        IComRepository comRepository
        ) : IUnitOfWork
    {

        // private data members
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly IComRepository _comRepository = comRepository;


        // function members
        public IComRepository Comments => _comRepository;

        // save changes
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
