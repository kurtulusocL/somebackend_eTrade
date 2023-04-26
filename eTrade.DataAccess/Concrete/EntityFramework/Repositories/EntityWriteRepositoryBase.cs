using eTrade.Core.DataAccess;
using eTrade.Core.Entities.EntityFramework;
using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTrade.DataAccess.EntityFramework.Repositories
{
    public class EntityWriteRepositoryBase<TEntity> : IEntityWriteRepository<TEntity> where TEntity : BaseEntity
    {
        ApplicationDbContext _context;
        public EntityWriteRepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Delete(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            TEntity model = await Table.FirstOrDefaultAsync(i => i.Id == Guid.Parse(id));
            return Delete(model);
        }

        public bool DeleteRange(List<TEntity> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public bool Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();
    }
}
