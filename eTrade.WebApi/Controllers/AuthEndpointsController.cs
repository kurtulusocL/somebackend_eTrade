using eTrade.Business.CQRS.Features.Commands.AuthEndpoint.AssignRoleEndpoint;
using eTrade.Business.CQRS.Features.Queries.AuthEndpoint.GetAllRolesEndpoint;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eTrade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthEndpointsController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetRolesToEndpoint(GetAllRolesToEndpointQueryRequest rolesToEndpointQueryRequest)
        {
            GetAllRolesToEndpointQueryResponse response = await _mediator.Send(rolesToEndpointQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoleEndpoint(AssignRoleEndpointCommandRequest assignRoleEndpointCommandRequest)
        {
            assignRoleEndpointCommandRequest.Type = typeof(Program);
            AssignRoleEndpointCommandResponse response = await _mediator.Send(assignRoleEndpointCommandRequest);
            return Ok(response);
        }
    }
}
