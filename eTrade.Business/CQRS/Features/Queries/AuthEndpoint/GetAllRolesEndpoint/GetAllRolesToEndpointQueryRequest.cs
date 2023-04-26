using MediatR;

namespace eTrade.Business.CQRS.Features.Queries.AuthEndpoint.GetAllRolesEndpoint
{
    public class GetAllRolesToEndpointQueryRequest : IRequest<GetAllRolesToEndpointQueryResponse>
    {
        public string Code { get; set; }
        public string Menu { get; set; }
    }
}
