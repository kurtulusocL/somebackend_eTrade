using MediatR;

namespace eTrade.Business.CQRS.Features.Commands.ProductImages.ChangeShowcase
{
    public class ChangeShowcaseImageCommandRequest : IRequest<ChangeShowcaseImageCommandResponse>
    {
        public string ImageId { get; set; }
        public string ProductId { get; set; }
    }
}
