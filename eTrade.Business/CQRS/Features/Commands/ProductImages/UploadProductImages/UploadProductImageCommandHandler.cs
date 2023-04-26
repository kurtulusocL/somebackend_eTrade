using eTrade.Business.Abstract.ReadServices;
using eTrade.Business.Abstract.WriteServices;
using eTrade.Core.CrossCuttingConcern.Storage.Abstractions.Storage;
using eTrade.Entities.Concrete;
using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.ProductImages.UploadProductImages
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly IProductReadService _productReadService;
        private readonly IProductImageWriteService _productImageWriteService;
        public UploadProductImageCommandHandler(IStorageService storageService, IProductReadService productReadService, IProductImageWriteService productImageWriteService)
        {
            _storageService = storageService;
            _productReadService = productReadService;
            _productImageWriteService = productImageWriteService;
        }

        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("file", request.Files);


          Entities.Concrete.Product product = await _productReadService.GetByIdAsync(request.Id);


            await _productImageWriteService.AddRangeAsync(result.Select(r => new ProductImage
            {
                Name = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<Entities.Concrete.Product>() { product }
            }).ToList());

            await _productImageWriteService.SaveAsync();
            return new();
        }
    }
}
