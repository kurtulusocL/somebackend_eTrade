using eTrade.Business.Abstract.ReadServices;
using eTrade.Entities.Concrete;
using MediatR;

namespace eTrade.Business.CQRS.Features.Queries.GetProductById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductReadService _productReadService;
        public GetByIdProductQueryHandler(IProductReadService productReadService)
        {
            _productReadService = productReadService;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productReadService.GetByIdAsync(request.Id, false);
            return new()
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}
