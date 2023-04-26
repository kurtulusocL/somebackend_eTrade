using eTrade.Business.Abstract.ReadServices;
using eTrade.Business.Abstract.WriteServices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using eTrade.Entities.Concrete;

namespace eTrade.Business.CQRS.Features.Commands.ProductImages.DeleteProductImages
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommandRequest, DeleteProductImageCommandResponse>
    {
        private readonly IProductReadService _productReadService;
        private readonly IProductWriteService _productWriteService;
        public DeleteProductImageCommandHandler(IProductReadService productReadService, IProductWriteService productWriteService)
        {
            _productReadService = productReadService;
            _productWriteService = productWriteService;
        }

        public async Task<DeleteProductImageCommandResponse> Handle(DeleteProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            eTrade.Entities.Concrete.Product? product = await _productReadService.Table.Include(p => p.ProductImages)
                 .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            ProductImage? productImageFile = product?.ProductImages.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

            if (productImageFile != null)
                product?.ProductImages.Remove(productImageFile);

            await _productWriteService.SaveAsync();
            return new();
        }
    }
}
