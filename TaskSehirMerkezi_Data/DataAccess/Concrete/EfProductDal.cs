using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using TaskSehirTeknolojileri_Core.DataAccess.EntityFramework;
using TaskSehirTeknolojileri_Data.DataAccess.Abstract;
using TaskSehirTeknolojileri_Data.DataAccess.Concrete.Context;
using TaskSehirTeknolojileri_Data.Entities.Concrete;


namespace TaskSehirTeknolojileri_Data.DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, AppDbContextBase>, IProductDal
    {
        private readonly AppDbContextBase _appDbContextBase;

        public EfProductDal(AppDbContextBase appDbContextBase)
        {
            _appDbContextBase = appDbContextBase;
        }
        public async Task<List<Product>> ProductWithCategory(Expression<Func<Product, bool>> filter = null)
        {
            return await _appDbContextBase.Products.Include(x => x.Category).Where(filter).ToListAsync();
        }

    }
}
