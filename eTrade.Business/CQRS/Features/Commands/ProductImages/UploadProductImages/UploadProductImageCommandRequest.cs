using MediatR;
using Microsoft.AspNetCore.Http;

namespace eTrade.Business.CQRS.Features.Commands.ProductImages.UploadProductImages
{
    public class UploadProductImageCommandRequest : IRequest<UploadProductImageCommandResponse>
    {
        public string Id { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
