using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.ProductImages.DeleteProductImages
{
    public class DeleteProductImageCommandRequest : IRequest<DeleteProductImageCommandResponse>
    {
        public string Id { get; set; }
        public string? ImageId { get; set; }
    }
}
