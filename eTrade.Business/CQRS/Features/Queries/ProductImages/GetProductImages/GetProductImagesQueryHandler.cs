using eTrade.Business.Abstract.ReadServices;
using eTrade.Entities.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace eTrade.Business.CQRS.Features.Queries.ProductImages.GetProductImages
{
    public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQueryRequest, List<GetProductImagesQueryResponse>>
    {
        private readonly IProductReadService _productReadService;
        readonly IConfiguration _configuration;
        public GetProductImagesQueryHandler(IProductReadService productReadService, IConfiguration configuration)
        {
            _productReadService = productReadService;
            _configuration = configuration;
        }

        public async Task<List<GetProductImagesQueryResponse>?> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            Product? product = await _productReadService.Table.Include(p => p.ProductImages)
                   .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
            return product?.ProductImages.Select(p => new GetProductImagesQueryResponse
            {
                Path = $"{_configuration["BaseStorageUrl"]}/{p.Path}",
                FileName = p.Name,
                Id = p.Id
            }).ToList();
        }
    }
}
