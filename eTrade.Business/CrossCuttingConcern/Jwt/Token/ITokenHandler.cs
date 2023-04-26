using eTrade.Core.CrossCuttingConcern.Dtos;
using eTrade.Entities.Concrete;

namespace eTrade.Business.CrossCuttingConcern.Jwt.Token
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();

    }
}
