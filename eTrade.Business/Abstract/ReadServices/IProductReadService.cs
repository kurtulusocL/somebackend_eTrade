﻿using eTrade.Core.DataAccess;
using eTrade.Entities.Concrete;

namespace eTrade.Business.Abstract.ReadServices
{
    public interface IProductReadService : IEntityReadRepository<Product>
    {
    }
}
