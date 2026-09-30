using Ecommerce_backend.Data;
using Ecommerce_backend.DTOs.CommentDTOs;
using Ecommerce_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_backend.Repositories.CommentRepository
{
    public class ComRepository(
        ApplicationDbContext dbcontext
        ) : IComRepository
    {

        private readonly ApplicationDbContext _dbcontext = dbcontext;

        
        public async Task<List<Comment>> BuyersCommentRepo(Guid prodId)
        {
            return await _dbcontext.Comments.Where(x => x.ProductId == prodId).AsNoTracking().ToListAsync();
        }


        public async Task CreateCommentUOW(Comment comment)
        {
            await _dbcontext.Comments.AddAsync(comment);
        }

        public async Task<CreateCommentResponse?> GetCreatedCommentAsync(Guid commentId)
        {
            return await _dbcontext.Comments
                                    .AsNoTracking()
                                    .Where(c => c.Id == commentId)
                                    .Select(c => new CreateCommentResponse
                                    {
                                        UserName = c.Buyer.UserName,
                                        FirstName = c.Buyer.FirstName,
                                        LastName = c.Buyer.LastName,
                                        Email = c.Buyer.Email,
                                        PhoneNumber = c.Buyer.PhoneNumber,
                                        Gender = c.Buyer.Gender,
                                        Name = c.Product.Name,
                                        Description = c.Product.Description,
                                        Price = c.Product.Price,
                                        Content = c.Content
                                    }).FirstOrDefaultAsync();
        }
    }
}
