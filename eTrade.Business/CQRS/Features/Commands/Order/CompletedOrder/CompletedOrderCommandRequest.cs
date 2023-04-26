using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.Order.CompletedOrder
{
    public class CompletedOrderCommandRequest : IRequest<CompletedOrderCommandResponse>
    {
        public string Id { get; set; }
    }
}
