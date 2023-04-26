using eTrade.Core.DataAccess;
using File = eTrade.Entities.Concrete.File;

namespace eTrade.Business.Abstract.WriteServices
{
    public interface IFileWriteService : IEntityWriteRepository<File>
    {
    }
}
