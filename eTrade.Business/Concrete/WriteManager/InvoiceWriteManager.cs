using eTrade.Business.Abstract.WriteServices;
using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;
using eTrade.DataAccess.EntityFramework.Repositories;
using eTrade.Entities.Concrete;

namespace eTrade.Business.Concrete.WriteManager
{
    public class InvoiceWriteManager : EntityWriteRepositoryBase<Invoice>, IInvoiceWriteService
    {
        public InvoiceWriteManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
