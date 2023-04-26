
namespace eTrade.Business.CQRS.Features.Queries.ProductImages.GetProductImages
{
    public class GetProductImagesQueryResponse
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public Guid Id { get; set; }
    }
}
