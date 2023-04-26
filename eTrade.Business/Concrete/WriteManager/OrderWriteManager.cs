using eTrade.Business.Abstract.WriteServices;
using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;
using eTrade.DataAccess.EntityFramework.Repositories;
using eTrade.Entities.Concrete;

namespace eTrade.Business.Concrete.WriteManager
{
    public class OrderWriteManager : EntityWriteRepositoryBase<Order>, IOrderWriteService
    {
        public OrderWriteManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
