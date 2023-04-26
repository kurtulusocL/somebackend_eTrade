using eTrade.Business.Abstract.Hubs;
using eTrade.Business.Abstract.WriteServices;
using eTrade.Business.CQRS.Features.Commands.Product.UpdateProduct;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eTrade.Business.CQRS.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandRespose>
    {
        private readonly IProductWriteService _productWriteService;
        private readonly ILogger<UpdateProductCommandHandler> _logger;
        readonly IProductHubService _productHubService;
        public CreateProductCommandHandler(IProductWriteService productWriteService, ILogger<UpdateProductCommandHandler> logger, IProductHubService productHubService)
        {
            _productWriteService = productWriteService;
            _logger = logger;
            _productHubService = productHubService;
        }
        public async Task<CreateProductCommandRespose> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteService.AddAsync(new()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            });
            await _productWriteService.SaveAsync();
            await _productHubService.ProductAddedMessageAsync($"{request.Name} product added.");
            _logger.LogInformation("Product Created");
            return new();
        }
    }
}
