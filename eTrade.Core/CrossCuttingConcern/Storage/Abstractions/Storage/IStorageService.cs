
namespace eTrade.Core.CrossCuttingConcern.Storage.Abstractions.Storage
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }
    }
}
