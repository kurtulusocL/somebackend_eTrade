using eTrade.Business.Abstract.Services.Authentication;
using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.ApplicationUser.ExternalLogins.FacebookLogin
{
    public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommandRequest, FacebookLoginCommandResponse>
    {
        readonly IExternalAuthService _authService;

        public FacebookLoginCommandHandler(IExternalAuthService authService)
        {
            _authService = authService;
        }

        public async Task<FacebookLoginCommandResponse> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.FacebookLoginAsync(request.AuthToken, 3600);
            return new()
            {
                Token = token
            };
        }
    }
}
