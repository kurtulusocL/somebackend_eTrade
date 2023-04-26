using eTrade.Core.CrossCuttingConcern.Dtos;

namespace eTrade.Business.CQRS.Features.Commands.ApplicationUser.ExternalLogins.FacebookLogin
{
    public class FacebookLoginCommandResponse
    {
        public TokenDto Token { get; set; }
    }
}
