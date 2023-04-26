using eTrade.Business.Abstract.WriteServices;
using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;
using eTrade.DataAccess.EntityFramework.Repositories;
using eTrade.Entities.Concrete;

namespace eTrade.Business.Concrete.WriteManager
{
    internal class ProductWriteManager : EntityWriteRepositoryBase<Product>, IProductWriteService
    {
        public ProductWriteManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
