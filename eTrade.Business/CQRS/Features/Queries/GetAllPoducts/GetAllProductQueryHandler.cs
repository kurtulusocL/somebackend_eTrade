using eTrade.Business.Abstract.ReadServices;
using eTrade.Business.CQRS.Features.Commands.Product.UpdateProduct;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eTrade.Business.CQRS.Features.Queries.GetAllPoducts
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IProductReadService _productReadService;
        private readonly ILogger<UpdateProductCommandHandler> _logger;
        public GetAllProductQueryHandler(IProductReadService productReadService, ILogger<UpdateProductCommandHandler> logger)
        {
            _productReadService = productReadService;
            _logger = logger;
        }
        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _productReadService.GetAll(false).Count();
            var products = _productReadService.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).Include(i => i.ProductImages).Select(i => new
            {
                i.Id,
                i.Name,
                i.Stock,
                i.Price,
                i.CreatedDate,
                i.UpdatedDate,
                i.ProductImages
            }).ToList();
            _logger.LogInformation("Products are came");
            return new()
            {
                Products = products,
                TotalProductCount = totalCount
            };
        }
    }
}
