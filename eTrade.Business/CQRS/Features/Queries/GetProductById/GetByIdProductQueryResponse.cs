
namespace eTrade.Business.CQRS.Features.Queries.GetProductById
{
    public class GetByIdProductQueryResponse
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
