using eTrade.Business.Abstract.Services;
using MediatR;

namespace eTrade.Business.CQRS.Features.Queries.AuthEndpoint.GetAllRolesEndpoint
{
    public class GetAllRolesToEndpointQueryHandler : IRequestHandler<GetAllRolesToEndpointQueryRequest, GetAllRolesToEndpointQueryResponse>
    {
        readonly IAuthEndpointService _authEndpointService;

        public GetAllRolesToEndpointQueryHandler(IAuthEndpointService authEndpointService)
        {
            _authEndpointService = authEndpointService;
        }

        public async Task<GetAllRolesToEndpointQueryResponse> Handle(GetAllRolesToEndpointQueryRequest request, CancellationToken cancellationToken)
        {
            var datas = await _authEndpointService.GetRolesToEndpointAsync(request.Code, request.Menu);
            return new()
            {
                Roles = datas
            };
        }
    }
}
