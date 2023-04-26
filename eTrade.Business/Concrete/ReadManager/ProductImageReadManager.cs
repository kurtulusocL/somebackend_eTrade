using eTrade.Business.Abstract.ReadServices;
using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;
using eTrade.DataAccess.EntityFramework.Repositories;
using eTrade.Entities.Concrete;

namespace eTrade.Business.Concrete.ReadManager
{
    public class ProductImageReadManager : EntityReadRepositoryBase<ProductImage>, IProductImageReadService
    {
        public ProductImageReadManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
