using eTrade.Core.Entities.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace eTrade.Core.DataAccess
{
    public interface IEntityRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

        //Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        //Task<T> GetAsync(Expression<Func<T, bool>> filter);
        //Task<bool> AddAsync(T entity);
        //Task<bool> UpdateAsync(T entity);
        //Task<bool> DeleteAsync(T entity);

        //List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //T Get(Expression<Func<T, bool>> filter);
        //Task Add(T entity);
        //bool Create(T entity);
        //bool Update(T entity);
        //bool Delete(T entity);
    }
}
