using eTrade.Core.CrossCuttingConcern.ViewModels.BasketItemVM;
using eTrade.Entities.Concrete;

namespace eTrade.Business.Abstract.Services
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> GetBasketItemsAsync();
        public Task AddItemToBasketAsync(CreateBasketItemVM basketItem);
        public Task UpdateQuantityAsync(UpdateBasketItemVM basketItem);
        public Task RemoveBasketItemAsync(string basketItemId);
        public Basket? GetUserActiveBasket { get; }
    }
}
