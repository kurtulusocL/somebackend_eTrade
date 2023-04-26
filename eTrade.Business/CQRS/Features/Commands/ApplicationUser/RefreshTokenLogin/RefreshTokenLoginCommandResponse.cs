using eTrade.Core.CrossCuttingConcern.Dtos;

namespace eTrade.Business.CQRS.Features.Commands.ApplicationUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandResponse
    {
        public TokenDto Token { get; set; }
    }
}
