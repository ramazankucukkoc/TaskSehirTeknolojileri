using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Core.DataAccess.EntityFramework;
using TaskSehirTeknolojileri_Data.DataAccess.Abstract;
using TaskSehirTeknolojileri_Data.DataAccess.Concrete.Context;
using TaskSehirTeknolojileri_Data.Entities.Concrete;


namespace TaskSehirTeknolojileri_Data.DataAccess.Concrete
{
    public class EfRefreshTokenDal:EfEntityRepositoryBase<UserRefreshToken,AppDbContextBase>,IUserRefreshTokenDal
    {
    }
}
