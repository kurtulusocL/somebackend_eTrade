
namespace eTrade.Core.CrossCuttingConcern.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public string? BasketId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
