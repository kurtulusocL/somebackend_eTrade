using eTrade.Business.Abstract.Services;
using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.Product.UpdateStockQrCodeToProduct
{
    public class UpdateStockQrCodeToProductCommandHandler : IRequestHandler<UpdateStockQrCodeToProductCommandRequest, UpdateStockQrCodeToProductCommandResponse>
    {
        readonly IProductService _productService;

        public UpdateStockQrCodeToProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<UpdateStockQrCodeToProductCommandResponse> Handle(UpdateStockQrCodeToProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productService.StockUpdateToProductAsync(request.ProductId, request.Stock);
            return new();
        }
    }
}
