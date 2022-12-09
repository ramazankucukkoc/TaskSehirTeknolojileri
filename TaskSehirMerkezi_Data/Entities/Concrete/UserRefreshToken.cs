using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Core.Entities;

namespace TaskSehirTeknolojileri_Data.Entities.Concrete
{
    public class UserRefreshToken:IEntity
    {
        public string UserId { get; set; }

        public string Code { get; set; }

        public DateTime Expriration { get; set; }
    }
}
