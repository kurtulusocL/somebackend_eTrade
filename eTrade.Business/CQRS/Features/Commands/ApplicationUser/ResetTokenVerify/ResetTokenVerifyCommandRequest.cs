using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.ApplicationUser.ResetTokenVerify
{
    public class ResetTokenVerifyCommandRequest : IRequest<ResetTokenVerifyCommandResponse>
    {
        public string ResetToken { get; set; }
        public string UserId { get; set; }
    }
}
