using eTrade.Core.CrossCuttingConcern.Storage.Abstractions.Storage;
using eTrade.Core.CrossCuttingConcern.Storage.Base;
using eTrade.Core.CrossCuttingConcern.Storage.Concretes.Azure;
using eTrade.Core.CrossCuttingConcern.Storage.Concretes.Local;
using eTrade.Core.CrossCuttingConcern.Toolbox.Enum;
using Microsoft.Extensions.DependencyInjection;

namespace eTrade.Core.CrossCuttingConcern.DependencyInjection.ServiceDependency
{
    public static class ServiceRegistration
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>(); 
        }
        public static void AddStorage<T>(this IServiceCollection services) where T : StorageBase, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
        public static void AddStorage<T>(this IServiceCollection services, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    services.AddScoped<IStorage, AzureStorage>();
                    break;               
                default:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
