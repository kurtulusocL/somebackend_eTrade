using eTrade.Business.Abstract.ReadServices;
using eTrade.Business.Abstract.Services;
using eTrade.Business.Abstract.WriteServices;
using eTrade.Core.CrossCuttingConcern.Dtos.OrderDtos;
using eTrade.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace eTrade.Business.Concrete.ServiceManager
{
    public class OrderManager : IOrderService
    {
        readonly IOrderWriteService _orderWriteService;
        readonly IOrderReadService _orderReadService;
        readonly ICompletedOrderWriteService _completedOrderWriteService;
        readonly ICompletedOrderReadService _completedOrderReadService;

        public OrderManager(IOrderWriteService orderWriteService, IOrderReadService orderReadService, ICompletedOrderWriteService completedOrderWriteService, ICompletedOrderReadService completedOrderReadService)
        {
            _orderWriteService = orderWriteService;
            _orderReadService = orderReadService;
            _completedOrderWriteService = completedOrderWriteService;
            _completedOrderReadService = completedOrderReadService;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrder)
        {
            var orderCode = (new Random().NextDouble() * 10000).ToString();
            orderCode = orderCode.Substring(orderCode.IndexOf(".") + 1, orderCode.Length - orderCode.IndexOf(".") - 1);

            await _orderWriteService.AddAsync(new()
            {
                Address = createOrder.Address,
                Id = Guid.Parse(createOrder.BasketId),
                Description = createOrder.Description,
                OrderCode = orderCode,
                OrderDate=createOrder.OrderDate
            });
            await _orderWriteService.SaveAsync();
        }

        public async Task<ListOrderDto> GetAllOrdersAsync(int page, int size)
        {
            var query = _orderReadService.Table.Include(o => o.Basket)
                      .ThenInclude(b => b.User)
                      .Include(o => o.Basket)
                         .ThenInclude(b => b.BasketItems)
                         .ThenInclude(bi => bi.Product);

            var data = query.Skip(page * size).Take(size);

            var data2 = from order in data
                        join completedOrder in _completedOrderReadService.Table
                           on order.Id equals completedOrder.OrderId into co
                        from _co in co.DefaultIfEmpty()
                        select new
                        {
                            Id = order.Id,
                            CreatedDate = order.CreatedDate,
                            OrderCode = order.OrderCode,
                            Basket = order.Basket,
                            OrderDate = order.OrderDate,
                            Completed = _co != null ? true : false
                        };

            return new()
            {
                TotalOrderCount = await query.CountAsync(),
                Orders = await data2.Select(o => new
                {
                    Id = o.Id,
                    CreatedDate = o.CreatedDate,
                    OrderCode = o.OrderCode,
                    TotalPrice = o.Basket.BasketItems.Sum(bi => bi.Product.Price * bi.Quantity),
                    UserName = o.Basket.User.UserName,                    
                    o.Completed
                }).ToListAsync()
            };
        }

        public async Task<SingleOrderDto> GetOrderByIdAsync(string id)
        {
            var data = _orderReadService.Table
                                 .Include(o => o.Basket)
                                     .ThenInclude(b => b.BasketItems)
                                         .ThenInclude(bi => bi.Product);

            var data2 = await (from order in data
                               join completedOrder in _completedOrderReadService.Table
                                    on order.Id equals completedOrder.OrderId into co
                               from _co in co.DefaultIfEmpty()
                               select new
                               {
                                   Id = order.Id,
                                   CreatedDate = order.CreatedDate,
                                   OrderCode = order.OrderCode,
                                   Basket = order.Basket,
                                   Completed = _co != null ? true : false,
                                   Address = order.Address,
                                   Description = order.Description
                               }).FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));

            return new()
            {
                Id = data2.Id.ToString(),
                BasketItems = data2.Basket.BasketItems.Select(bi => new
                {
                    bi.Product.Name,
                    bi.Product.Price,
                    bi.Quantity
                }),
                Address = data2.Address,
                CreatedDate = data2.CreatedDate,
                Description = data2.Description,
                OrderCode = data2.OrderCode,
                Completed = data2.Completed
            };
        }

        public async Task<(bool, CompletedOrderDto)> CompletedOrderAsync(string id)
        {
            Order? order = await _orderReadService.Table
                .Include(o => o.Basket)
                .ThenInclude(b => b.User)
                .FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));

            if (order != null)
            {
                await _completedOrderWriteService.AddAsync(new() { OrderId = Guid.Parse(id) });
                return (await _completedOrderWriteService.SaveAsync() > 0, new()
                {
                    OrderCode = order.OrderCode,
                    OrderDate = order.CreatedDate,
                    Username = order.Basket.User.UserName,
                    EMail = order.Basket.User.Email
                });
            }
            return (false, null);
        }
    }
}
