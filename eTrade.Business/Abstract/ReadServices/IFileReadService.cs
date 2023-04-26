using eTrade.Core.DataAccess;
using File = eTrade.Entities.Concrete.File;

namespace eTrade.Business.Abstract.ReadServices
{
    public interface IFileReadService : IEntityReadRepository<File>
    {
    }
}
