using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace eTrade.Business.DependencyResolver.DependencyInjection.ServiceDependency
{
    public static class ServiceRegistration
    {
        public static void AddCQRSServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration));
        }
    }
}
