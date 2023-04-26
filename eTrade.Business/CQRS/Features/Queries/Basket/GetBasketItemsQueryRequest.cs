using MediatR;

namespace eTrade.Business.CQRS.Features.Queries.Basket
{
    public class GetBasketItemsQueryRequest : IRequest<List<GetBasketItemsQueryResponse>>
    {
    }
}
