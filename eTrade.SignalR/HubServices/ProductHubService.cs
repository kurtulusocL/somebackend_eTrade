using eTrade.Business.Abstract.Hubs;
using eTrade.SignalR.Functions;
using eTrade.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace eTrade.SignalR.HubServices
{
    public class ProductHubService : IProductHubService
    {
        readonly IHubContext<ProductHub> _hubContext;
        public ProductHubService(IHubContext<ProductHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task ProductAddedMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync(RecieveFunctionsName.ProductAddedMessage, message);
        }
    }
}