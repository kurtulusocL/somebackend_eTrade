using eTrade.Business.Abstract.WriteServices;
using Microsoft.EntityFrameworkCore;

namespace eTrade.Business.CQRS.Features.Commands.ProductImages.ChangeShowcase
{
    public class ChangeShowcaseImageCommandHandler : MediatR.IRequestHandler<ChangeShowcaseImageCommandRequest, ChangeShowcaseImageCommandResponse>
    {
        readonly IProductImageWriteService _productImageWriteRepository;

        public ChangeShowcaseImageCommandHandler(IProductImageWriteService productImageWriteRepository)
        {
            _productImageWriteRepository = productImageWriteRepository;
        }

        public async Task<ChangeShowcaseImageCommandResponse> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
        {
            var query = _productImageWriteRepository.Table
                      .Include(p => p.Products)
                      .SelectMany(p => p.Products, (pif, p) => new
                      {
                          pif,
                          p
                      });

            var data = await query.FirstOrDefaultAsync(p => p.p.Id == Guid.Parse(request.ProductId) && p.pif.Showcase);

            if (data != null)
                data.pif.Showcase = false;

            var image = await query.FirstOrDefaultAsync(p => p.pif.Id == Guid.Parse(request.ImageId));
            if (image != null)
                image.pif.Showcase = true;
            await _productImageWriteRepository.SaveAsync();
            return new();
        }
    }
}
