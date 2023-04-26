using eTrade.Business.Abstract.Hubs;
using eTrade.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;

namespace eTrade.SignalR.ServiceDependency
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
            collection.AddSignalR();
            collection.AddTransient<IProductHubService, ProductHubService>();
            collection.AddTransient<IOrderHubService, OrderHubService>();
        }
    }
}
