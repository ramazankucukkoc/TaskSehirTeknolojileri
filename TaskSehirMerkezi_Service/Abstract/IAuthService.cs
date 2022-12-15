using NLayer_Backend_Core.Utilities.Security.Jwt;
using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.Entities.Concrete;
using TaskSehirTeknolojileri_Data.Entities.Dtos;

namespace TaskSehirTeknolojileri_Service.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> RegisterAsync(UserRegisterDto userRegisterDto, string password);
        Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user);
        Task<IDataResult<User>> LoginAsync(UserLoginDto userLoginDto);
        Task<IDataResult<User>> UserExists(string email);


    }
}
