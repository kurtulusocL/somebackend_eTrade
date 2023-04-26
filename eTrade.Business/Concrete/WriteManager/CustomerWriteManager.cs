using eTrade.Business.Abstract.WriteServices;
using eTrade.DataAccess.EntityFramework.Repositories;
using eTrade.Entities.Concrete;
using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;

namespace eTrade.Business.Concrete.WriteManager
{
    public class CustomerWriteManager : EntityWriteRepositoryBase<Customer>, ICustomerWriteService
    {
        public CustomerWriteManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
