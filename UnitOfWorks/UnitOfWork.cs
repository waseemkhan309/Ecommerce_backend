using Ecommerce_backend.Data;


namespace Ecommerce_backend.UnitOfWorks
{
    public class UnitOfWorkService(
        ApplicationDbContext dbContext
        ) : IUnitOfWork
    {

        // private data members
        private readonly ApplicationDbContext _dbContext = dbContext;


        // function members

        // save changes
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
