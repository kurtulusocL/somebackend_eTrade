using eTrade.Business.Abstract.Services.Authentication;

namespace eTrade.Business.Abstract.Services
{
    public interface IAuthService : IExternalAuthService, IInternalAuthService
    {
        Task PasswordResetAsnyc(string email);
        Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
    }
}
