
namespace eTrade.Core.CrossCuttingConcern.Dtos.OrderDtos
{
    public class SingleOrderDto
    {
        public string Address { get; set; }
        public object BasketItems { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string OrderCode { get; set; }
        public bool Completed { get; set; }
    }
}
