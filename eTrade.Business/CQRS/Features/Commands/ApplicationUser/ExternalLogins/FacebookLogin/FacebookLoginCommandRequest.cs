using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.ApplicationUser.ExternalLogins.FacebookLogin
{
    public class FacebookLoginCommandRequest : IRequest<FacebookLoginCommandResponse>
    {
        public string AuthToken { get; set; }
    }
}
