
using Ecommerce_backend.DTOs.CommentDTOs;
using Ecommerce_backend.Models;

namespace Ecommerce_backend.Repositories.CommentRepository
{
    public interface IComRepository
    {
        Task<List<Comment>> BuyersCommentRepo(Guid prodId);
        Task CreateCommentUOW(Comment comment);

        // get comment by ID
        Task<CreateCommentResponse?> GetCreatedCommentAsync(Guid commentId);

        //Task<Comment> updateComment();
        //Task<bool> deleteComment();
    }
}
