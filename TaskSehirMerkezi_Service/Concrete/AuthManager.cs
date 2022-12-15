
using Microsoft.EntityFrameworkCore.Diagnostics;
using NLayer_Backend_Core.Utilities.Security.Jwt;
using TaskSehirTeknolojileri_Core.Utilities.Jwt.Hashing;
using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.Entities.Concrete;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;

namespace TaskSehirTeknolojileri_Service.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user)
        {
            var claims = await _userService.GetOperationClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new DataResult<AccessToken>(ResultStatus.Success, accessToken);
        }
        public async Task<IDataResult<User>> LoginAsync(UserLoginDto userLoginDto)
        {
            var userToCheck = await _userService.GetByEmail(userLoginDto.Email);
            if (userToCheck == null)
            {
                return new DataResult<User>(ResultStatus.Error, "User Not Found", null);
            }
            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new DataResult<User>(ResultStatus.Error, "Password and Email wrong", null);

            }
            return new DataResult<User>(ResultStatus.Success, userToCheck.Data);
        }

        public async Task<IDataResult<User>> RegisterAsync(UserRegisterDto userRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            await _userService.AddAsync(user);
            return new DataResult<User>(ResultStatus.Success,"Kullanıcı kaydedildi.", user);
        }

        public async Task<IDataResult<User>> UserExists(string email)
        {
            var userIsExists = await _userService.GetByEmail(email);
            if (userIsExists!=null)
            {
                return new DataResult<User>(ResultStatus.Error, "User Not Found", null);
            }
            return new DataResult<User>(ResultStatus.Success, "There is User.Process is successfully", userIsExists.Data);
        }
    }
}
