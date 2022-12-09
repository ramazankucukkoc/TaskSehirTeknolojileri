using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.Entities.Dtos;

namespace TaskSehirTeknolojileri_Service.Abstract
{
    public interface IRefreshTokenService:IGenericService<UserRefreshTokenDto>
    {
        Task<IDataResult<UserRefreshTokenDto>> GetByIdAsync(string id);
        Task<IDataResult<UserRefreshTokenDto>> GetRefreshTokenAsync(string refreshToken);
    }
}
