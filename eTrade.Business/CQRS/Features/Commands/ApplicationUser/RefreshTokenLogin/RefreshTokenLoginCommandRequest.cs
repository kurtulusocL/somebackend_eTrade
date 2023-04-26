using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.ApplicationUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandRequest : IRequest<RefreshTokenLoginCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}
