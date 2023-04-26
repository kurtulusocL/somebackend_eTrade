using MediatR;

namespace eTrade.Business.CQRS.Features.Queries.GetProductById
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public string Id { get; set; }
    }
}
