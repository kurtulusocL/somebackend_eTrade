using eTrade.Business.Abstract.WriteServices;
using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;
using eTrade.DataAccess.EntityFramework.Repositories;

namespace eTrade.Business.Concrete.WriteManager
{
    public class EndpointWriteManager : EntityWriteRepositoryBase<Endpoint>, IEndpointWriteService
    {
        public EndpointWriteManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
