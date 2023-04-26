using eTrade.Core.CrossCuttingConcern.Dtos;

namespace eTrade.Business.CQRS.Features.Commands.ApplicationUser.ExternalLogins.GoogleLogin
{
    public class GoogleLoginCommandResponse
    {
        public TokenDto Token { get; set; }
    }
}
