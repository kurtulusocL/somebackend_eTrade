using eTrade.Business.Abstract.Services.Authentication;
using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.ApplicationUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IInternalAuthService _internalAuthService;
        public LoginUserCommandHandler(IInternalAuthService internalAuthService)
        {
            _internalAuthService = internalAuthService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _internalAuthService.LoginAsync(request.UsernameOrEmail, request.Password, 3600);
            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };
        }
    }
}
