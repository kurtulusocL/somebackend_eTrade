using eTrade.Core.CrossCuttingConcern.Dtos;

namespace eTrade.Business.Abstract.Services.Authentication
{
    public interface IExternalAuthService
    {
        Task<TokenDto> FacebookLoginAsync(string authToken, int tokenLifeTime);
        Task<TokenDto> GoogleLoginAsync(string idToken, string provider, int tokenLifeTime);
    }
}
