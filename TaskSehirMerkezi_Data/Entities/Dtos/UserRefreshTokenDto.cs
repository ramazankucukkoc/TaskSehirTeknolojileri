using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Core.Entities;

namespace TaskSehirTeknolojileri_Data.Entities.Dtos
{
    public class UserRefreshTokenDto
    {
        public string UserId { get; set; }

        public string Code { get; set; }

        public DateTime Expiration { get; set; }
    }
}
