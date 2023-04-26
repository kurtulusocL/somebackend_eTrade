using MediatR;

namespace eTrade.Business.CQRS.Features.Queries.Roles.GetById
{
    public class GetRoleByIdQueryRequest : IRequest<GetRoleByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
