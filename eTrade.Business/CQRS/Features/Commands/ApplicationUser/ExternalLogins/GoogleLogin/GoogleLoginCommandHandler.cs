using eTrade.Business.Abstract.Services.Authentication;
using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.ApplicationUser.ExternalLogins.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        readonly IExternalAuthService _authService;

        public GoogleLoginCommandHandler(IExternalAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.GoogleLoginAsync(request.IdToken, request.Provider, 3600);
            return new()
            {
                Token = token
            };
        }
    }
}
