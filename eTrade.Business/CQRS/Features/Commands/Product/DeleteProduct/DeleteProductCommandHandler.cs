using eTrade.Business.Abstract.WriteServices;
using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductWriteService _productWriteService;
        public DeleteProductCommandHandler(IProductWriteService productWriteService)
        {
            _productWriteService = productWriteService;
        }
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteService.DeleteAsync(request.Id);
            await _productWriteService.SaveAsync();
            return new();
        }
    }
}
