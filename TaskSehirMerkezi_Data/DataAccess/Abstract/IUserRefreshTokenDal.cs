using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Core.DataAccess;
using TaskSehirTeknolojileri_Data.Entities.Concrete;

namespace TaskSehirTeknolojileri_Data.DataAccess.Abstract
{
    public interface IUserRefreshTokenDal:IEntityRepository<UserRefreshToken>
    {
    }
}
