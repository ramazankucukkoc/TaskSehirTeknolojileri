using System.Linq.Expressions;
using TaskSehirTeknolojileri_Core.Entities;

namespace TaskSehirTeknolojileri_Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
    }
}
