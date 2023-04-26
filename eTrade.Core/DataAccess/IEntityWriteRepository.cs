using eTrade.Core.Entities.EntityFramework;

namespace eTrade.Core.DataAccess
{
    public interface IEntityWriteRepository<T> : IEntityRepository<T> where T : BaseEntity 
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Update(T entity);
        Task<bool> DeleteAsync(string id);
        bool Delete(T entity);
        bool DeleteRange(List<T> entities);
        Task<int> SaveAsync();

    }
}
