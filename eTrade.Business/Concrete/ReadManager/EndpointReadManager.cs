using eTrade.Business.Abstract.ReadServices;
using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;
using eTrade.DataAccess.EntityFramework.Repositories;
using eTrade.Entities.Concrete;

namespace eTrade.Business.Concrete.ReadManager
{
    public class EndpointReadManager : EntityReadRepositoryBase<Endpoint>, IEndpointReadService
    {
        public EndpointReadManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
