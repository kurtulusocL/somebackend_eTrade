using eTrade.Core.Entities.EntityFramework;
using System.Linq.Expressions;

namespace eTrade.Core.DataAccess
{
    public interface IEntityReadRepository<T> : IEntityRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}
