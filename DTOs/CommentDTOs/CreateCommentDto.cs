using Ecommerce_backend.Models;

namespace Ecommerce_backend.DTOs.CommentDTOs
{
    public class CreateCommentDto
    {
        public Guid ProductId { get; set; }
        public Guid BuyerId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
