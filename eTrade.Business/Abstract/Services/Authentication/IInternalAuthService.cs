using eTrade.Core.CrossCuttingConcern.Dtos;

namespace eTrade.Business.Abstract.Services.Authentication
{
    public interface IInternalAuthService
    {
        Task<TokenDto> LoginAsync(string userNameOrEmail, string password, int tokenLifeTime);
        Task<TokenDto> RefreshTokenLoginAsync(string refreshToken);
    }
}
