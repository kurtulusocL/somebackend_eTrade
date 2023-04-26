using MediatR;

namespace eTrade.Business.CQRS.Features.Queries.Order.GetAllOrderById
{
    public class GetOrderByIdQueryRequest : IRequest<GetOrderByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
