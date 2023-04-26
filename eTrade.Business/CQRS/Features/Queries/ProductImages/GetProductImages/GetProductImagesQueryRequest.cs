using MediatR;

namespace eTrade.Business.CQRS.Features.Queries.ProductImages.GetProductImages
{
    public class GetProductImagesQueryRequest : IRequest<List<GetProductImagesQueryResponse>>
    {
        public string Id { get; set; }
    }
}
