using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.ApplicationUser.ResetPassword
{
    public class PasswordResetCommandRequest : IRequest<PasswordResetCommandResponse>
    {
        public string Email { get; set; }
    }
}
