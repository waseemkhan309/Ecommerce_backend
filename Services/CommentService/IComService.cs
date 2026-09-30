using Ecommerce_backend.DTOs.CommentDTOs;
using Ecommerce_backend.Models;

namespace Ecommerce_backend.Services.CommentService
{
    public interface IComService
    {
        Task<List<Comment>> BuyersCommentList(Guid prodId);
        Task<CreateCommentResponse> CreateCommentService(CreateCommentDto createCommentDto);
    }
}
