using eTrade.Business.Abstract.ReadServices;
using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;
using eTrade.DataAccess.EntityFramework.Repositories;
using eTrade.Entities.Concrete;

namespace eTrade.Business.Concrete.ReadManager
{
    public class ProductReadManager : EntityReadRepositoryBase<Product>, IProductReadService
    {
        public ProductReadManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
