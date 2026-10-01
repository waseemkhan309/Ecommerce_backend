using Ecommerce_backend.DTOs.CommentDTOs;
using Ecommerce_backend.Models;
using Ecommerce_backend.Repositories.CommentRepository;
using Ecommerce_backend.UnitOfWorks;

namespace Ecommerce_backend.Services.CommentService
{
    public class ComService(
          IComRepository comRepository,
          IUnitOfWork unitOfWork
        ) : IComService
    {

        private readonly IComRepository _comRepository = comRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<CreateCommentResponse> CreateCommentService(CreateCommentDto createCommentDto)
        {
            var commentObj = new Comment
            {
                Id = Guid.NewGuid(),
                BuyerId = createCommentDto.BuyerId,
                ProductId = createCommentDto.ProductId,
                Content = createCommentDto.Content,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            
            await _comRepository.CreateCommentUOW(commentObj);

            await _unitOfWork.SaveChangesAsync();

            var response = await _comRepository.GetCreatedCommentAsync(commentObj.Id);

            if(response == null)
            {
                throw new KeyNotFoundException("Comment could not be retrieved after creation.");
            }

            return response;
            
        }

        public async Task<List<Comment>> BuyersCommentList(Guid prodId)
        {
            if(prodId == Guid.Empty)
            {
                throw new ArgumentException("A valid product ID is required.");
            }
            
            return await _comRepository.BuyersCommentRepo(prodId);

        }
    }
}
