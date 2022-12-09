using System.Linq.Expressions;
using TaskSehirTeknolojileri_Core.DataAccess;
using TaskSehirTeknolojileri_Data.Entities.Concrete;

namespace TaskSehirTeknolojileri_Data.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Task<List<Product>> ProductWithCategory(Expression<Func<Product, bool>> filter = null);
    }
}
