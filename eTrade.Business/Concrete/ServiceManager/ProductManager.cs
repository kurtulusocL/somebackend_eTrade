using eTrade.Business.Abstract.ReadServices;
using eTrade.Business.Abstract.Services;
using eTrade.Business.Abstract.WriteServices;
using eTrade.Entities.Concrete;
using System.Text.Json;

namespace eTrade.Business.Concrete.ServiceManager
{
    public class ProductManager : IProductService
    {
        readonly IProductReadService _productReadService;
        readonly IProductWriteService _productWriteService;
        readonly IQRCodeService _qrCodeService;
        public ProductManager(IProductReadService productReadService, IQRCodeService qrCodeService, IProductWriteService productWriteService)
        {
            _productReadService = productReadService;
            _qrCodeService = qrCodeService;
            _productWriteService = productWriteService;
        }

        public async Task<byte[]> QrCodeToProductAsync(string productId)
        {
            Product product = await _productReadService.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            var plainObject = new
            {
                product.Id,
                product.Name,
                product.Price,
                product.Stock,
                product.CreatedDate
            };
            string plainText = JsonSerializer.Serialize(plainObject);

            return _qrCodeService.GenerateQRCode(plainText);
        }

        public async Task StockUpdateToProductAsync(string productId, int stock)
        {
            Product product = await _productReadService.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            product.Stock = stock;
            await _productWriteService.SaveAsync();
        }
    }
}
