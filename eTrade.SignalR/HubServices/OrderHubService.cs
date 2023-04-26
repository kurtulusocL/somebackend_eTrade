using eTrade.Business.Abstract.Hubs;
using eTrade.SignalR.Functions;
using eTrade.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace eTrade.SignalR.HubServices
{
    public class OrderHubService : IOrderHubService
    {
        readonly IHubContext<OrderHub> _hubContext;

        public OrderHubService(IHubContext<OrderHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task OrderAddedMessageAsync(string message)
            => await _hubContext.Clients.All.SendAsync(RecieveFunctionsName.OrderAddedMessage, message);
    }
}
