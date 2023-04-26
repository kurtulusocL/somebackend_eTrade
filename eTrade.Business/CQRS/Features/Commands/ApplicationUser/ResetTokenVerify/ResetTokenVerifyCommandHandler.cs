using eTrade.Business.Abstract.Services;
using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.ApplicationUser.ResetTokenVerify
{
    public class ResetTokenVerifyCommandHandler : IRequestHandler<ResetTokenVerifyCommandRequest, ResetTokenVerifyCommandResponse>
    {
        readonly IAuthService _authService;

        public ResetTokenVerifyCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ResetTokenVerifyCommandResponse> Handle(ResetTokenVerifyCommandRequest request, CancellationToken cancellationToken)
        {
            bool state = await _authService.VerifyResetTokenAsync(request.ResetToken, request.UserId);
            return new()
            {
                State = state
            };
        }
    }
}
