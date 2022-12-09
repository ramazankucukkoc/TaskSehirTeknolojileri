using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;

namespace TaskSehirTeknolojileri_Service.Abstract
{
    public interface IAuthenticetionService
    {

        Task<IDataResult<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<IDataResult<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken);
    }
}
