using eTrade.Business.Abstract.WriteServices;
using eTrade.DataAccess.EntityFramework.Repositories;
using File = eTrade.Entities.Concrete.File;
using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;

namespace eTrade.Business.Concrete.WriteManager
{
    public class FileWriteManager : EntityWriteRepositoryBase<File>, IFileWriteService
    {
        public FileWriteManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
