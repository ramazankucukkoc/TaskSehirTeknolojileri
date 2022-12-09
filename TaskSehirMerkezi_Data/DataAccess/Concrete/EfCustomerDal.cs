


using TaskSehirTeknolojileri_Core.DataAccess.EntityFramework;
using TaskSehirTeknolojileri_Data.DataAccess.Abstract;
using TaskSehirTeknolojileri_Data.DataAccess.Concrete.Context;
using TaskSehirTeknolojileri_Data.Entities.Concrete;

namespace TaskSehirTeknolojileri_Data.DataAccess.Concrete
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, AppDbContextBase>, ICustomerDal
    {

    }
}
