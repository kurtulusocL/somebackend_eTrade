using eTrade.Core.DataAccess;
using eTrade.Entities.Concrete;

namespace eTrade.Business.Abstract.WriteServices
{
    public interface IProductWriteService : IEntityWriteRepository<Product>
    {
    }
}
