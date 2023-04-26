
namespace eTrade.Business.CrossCuttingConcern.RequestParameters
{
    public record Pagination
    {
        public int Size { get; set; } = 0;
        public int Page { get; set; } = 5;
    }
}
