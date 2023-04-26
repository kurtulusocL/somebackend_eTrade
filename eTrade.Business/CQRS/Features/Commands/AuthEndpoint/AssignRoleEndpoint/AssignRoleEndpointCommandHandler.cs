using eTrade.Business.Abstract.Services;
using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.AuthEndpoint.AssignRoleEndpoint
{
    public class AssignRoleEndpointCommandHandler : IRequestHandler<AssignRoleEndpointCommandRequest, AssignRoleEndpointCommandResponse>
    {
        readonly IAuthEndpointService _authEndpointService;

        public AssignRoleEndpointCommandHandler(IAuthEndpointService authEndpointService)
        {
            _authEndpointService = authEndpointService;
        }

        public async Task<AssignRoleEndpointCommandResponse> Handle(AssignRoleEndpointCommandRequest request, CancellationToken cancellationToken)
        {
            await _authEndpointService.AssignRoleEndpointAsync(request.Roles, request.Menu, request.Code, request.Type);
            return new(){};
        }
    }
}
