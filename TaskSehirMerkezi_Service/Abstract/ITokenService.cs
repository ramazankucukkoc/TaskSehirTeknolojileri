using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Data.Entities.Concrete;
using TaskSehirTeknolojileri_Data.Entities.Dtos;

namespace TaskSehirTeknolojileri_Service.Abstract
{
    public interface ITokenService
    {
        TokenDto CreateToken(User user);



    }
}
