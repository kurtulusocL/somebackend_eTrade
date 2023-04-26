using eTrade.Business.Abstract.ReadServices;
using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;
using eTrade.DataAccess.EntityFramework.Repositories;
using File = eTrade.Entities.Concrete.File;

namespace eTrade.Business.Concrete.ReadManager
{
    public class FileReadManager : EntityReadRepositoryBase<File>, IFileReadService
    {
        public FileReadManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
