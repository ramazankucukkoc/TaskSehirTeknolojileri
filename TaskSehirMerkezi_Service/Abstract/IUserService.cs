using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.Entities.Dtos;

namespace TaskSehirTeknolojileri_Service.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<IDataResult<UserAppDto>> GetUserAsync(string userName);

    }
}
