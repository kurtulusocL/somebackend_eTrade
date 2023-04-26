using eTrade.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;

namespace eTrade.SignalR.ServiceDependency
{
    public static class HapRegistration
    {
        public static void MapHubs(this WebApplication application)
        {
            application.MapHub<ProductHub>("/product-hub");
            application.MapHub<OrderHub>("/orders-hub");
        }
    }
}
