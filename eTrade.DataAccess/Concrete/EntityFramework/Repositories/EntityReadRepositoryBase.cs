using eTrade.Core.DataAccess;
using eTrade.Core.Entities.EntityFramework;
using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eTrade.DataAccess.EntityFramework.Repositories
{
    public class EntityReadRepositoryBase<TEntity> : IEntityReadRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public EntityReadRepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public IQueryable<TEntity> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<TEntity> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(i => i.Id ==Guid.Parse(id));
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();           
            return await query.FirstOrDefaultAsync(filter);
        }

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> filter, bool tracking = true)
        {
            var query = Table.Where(filter);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
    }
}
