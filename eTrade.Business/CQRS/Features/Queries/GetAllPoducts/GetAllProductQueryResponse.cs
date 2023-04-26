
namespace eTrade.Business.CQRS.Features.Queries.GetAllPoducts
{
    public class GetAllProductQueryResponse 
    {
        public int TotalProductCount { get; set; }
        public object Products { get; set; }
    }
}
