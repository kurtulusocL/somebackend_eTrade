using MediatR;

namespace eTrade.Business.CQRS.Features.Queries.User.GetRolesToUser
{
    public class GetRolesToUserQueryRequest : IRequest<GetRolesToUserQueryResponse>
    {
        public string UserId { get; set; }
    }
}
