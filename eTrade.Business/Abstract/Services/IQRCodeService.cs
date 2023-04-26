
namespace eTrade.Business.Abstract.Services
{
    public interface IQRCodeService
    {
        byte[] GenerateQRCode(string text);
    }
}
