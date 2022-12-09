using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskSehirTeknolojileri_Core.Entities;

namespace TaskSehirTeknolojileri_Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            using (var context = new TContext())
            {
                return await (predicate == null ? context.Set<TEntity>().CountAsync() : context.Set<TEntity>().CountAsync(predicate));
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }

        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
