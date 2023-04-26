using eTrade.Business.Abstract.ReadServices;
using eTrade.Business.Abstract.Services;
using eTrade.Business.Abstract.WriteServices;
using eTrade.Core.CrossCuttingConcern.ViewModels.BasketItemVM;
using eTrade.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eTrade.Business.Concrete.ServiceManager
{
    public class BasketManager : IBasketService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        readonly IOrderReadService _orderReadService;
        readonly IBasketWriteService _basketWriteService;
        readonly IBasketReadService _basketReadService;
        readonly IBasketItemWriteService _basketItemWriteService;
        readonly IBasketItemReadService _basketItemReadService;
        public BasketManager(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IOrderReadService orderReadService, IBasketWriteService basketWriteService, IBasketItemWriteService basketItemWriteService, IBasketItemReadService basketItemReadService, IBasketReadService basketReadService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _orderReadService = orderReadService;
            _basketWriteService = basketWriteService;
            _basketItemWriteService = basketItemWriteService;
            _basketItemReadService = basketItemReadService;
            _basketReadService = basketReadService;
        }

        private async Task<Basket?> ContextUser()
        {
            var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {
                AppUser? user = await _userManager.Users
                         .Include(u => u.Baskets)
                         .FirstOrDefaultAsync(u => u.UserName == username);

                var _basket = from basket in user.Baskets
                              join order in _orderReadService.Table
                              on basket.Id equals order.Id into BasketOrders
                              from order in BasketOrders.DefaultIfEmpty()
                              select new
                              {
                                  Basket = basket,
                                  Order = order
                              };

                Basket? targetBasket = null;
                if (_basket.Any(b => b.Order is null))
                    targetBasket = _basket.FirstOrDefault(b => b.Order is null)?.Basket;
                else
                {
                    targetBasket = new();
                    user.Baskets.Add(targetBasket);
                }

                await _basketWriteService.SaveAsync();
                return targetBasket;
            }
            throw new Exception("There was an unexpected error...");
        }

        public async Task AddItemToBasketAsync(CreateBasketItemVM basketItem)
        {
            Basket? basket = await ContextUser();
            if (basket != null)
            {
                BasketItem _basketItem = await _basketItemReadService.GetSingleAsync(bi => bi.BasketId == basket.Id && bi.ProductId == Guid.Parse(basketItem.ProductId));
                if (_basketItem != null)
                    _basketItem.Quantity++;
                else
                    await _basketItemWriteService.AddAsync(new()
                    {
                        BasketId = basket.Id,
                        ProductId = Guid.Parse(basketItem.ProductId),
                        Quantity = basketItem.Quantity
                    });

                await _basketItemWriteService.SaveAsync();
            }
        }

        public async Task<List<BasketItem>> GetBasketItemsAsync()
        {
            Basket? basket = await ContextUser();
            Basket? result = await _basketReadService.Table
                 .Include(b => b.BasketItems)
                 .ThenInclude(bi => bi.Product)
                 .FirstOrDefaultAsync(b => b.Id == basket.Id);

            return result.BasketItems
                .ToList();
        }

        public async Task RemoveBasketItemAsync(string basketItemId)
        {
            BasketItem? basketItem = await _basketItemReadService.GetByIdAsync(basketItemId);
            if (basketItem != null)
            {
                _basketItemWriteService.Delete(basketItem);
                await _basketItemWriteService.SaveAsync();
            }
        }

        public async Task UpdateQuantityAsync(UpdateBasketItemVM basketItem)
        {
            BasketItem? _basketItem = await _basketItemReadService.GetByIdAsync(basketItem.BasketItemId);
            if (_basketItem != null)
            {
                _basketItem.Quantity = basketItem.Quantity;
                await _basketItemWriteService.SaveAsync();
            }
        }

        public Basket? GetUserActiveBasket
        {
            get
            {
                Basket? basket = ContextUser().Result;
                return basket;
            }
        }
    }
}
