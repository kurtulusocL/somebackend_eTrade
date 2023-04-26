using eTrade.Business.Abstract.ReadServices;
using eTrade.Business.Abstract.WriteServices;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eTrade.Business.CQRS.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductReadService _productReadService;
        private readonly IProductWriteService _productWriteService;
        private readonly ILogger<UpdateProductCommandHandler> _logger;
        public UpdateProductCommandHandler(IProductWriteService productWriteService, IProductReadService productReadService, ILogger<UpdateProductCommandHandler> logger)
        {
            _productReadService = productReadService;
            _productWriteService = productWriteService;
            _logger = logger;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Entities.Concrete.Product product = await _productReadService.GetByIdAsync(request.Id);
            product.Stock = request.Stock;
            product.Name = request.Name;
            product.Price = request.Price;
            await _productWriteService.SaveAsync();
            _logger.LogInformation("Product Updated");
            return new();
        }
    }
}
