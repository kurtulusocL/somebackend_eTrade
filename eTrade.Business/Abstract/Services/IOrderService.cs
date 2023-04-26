using eTrade.Core.CrossCuttingConcern.Dtos.OrderDtos;

namespace eTrade.Business.Abstract.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto createOrder);
        Task<ListOrderDto> GetAllOrdersAsync(int page, int size);
        Task<SingleOrderDto> GetOrderByIdAsync(string id);
        Task<(bool, CompletedOrderDto)> CompletedOrderAsync(string id);
    }
}
