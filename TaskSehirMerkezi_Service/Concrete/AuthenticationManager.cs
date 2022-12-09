using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.Entities.Concrete;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Data.UnitOfWork;
using TaskSehirTeknolojileri_Service.Abstract;

namespace TaskSehirTeknolojileri_Service.Concrete
{
    public class AuthenticationManager:IAuthenticetionService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly IRefreshTokenService _genericService;
        private  readonly IUnitOfWork _unitOfWork;

        public AuthenticationManager(ITokenService tokenService, UserManager<User> userManager, 
            IRefreshTokenService genericService, IUnitOfWork unitOfWork)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _genericService = genericService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null) throw new ArgumentException(nameof(loginDto));

            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return new DataResult<TokenDto>(ResultStatus.Error, "", null);

            if (!await _userManager.CheckPasswordAsync(user,loginDto.Password))
            {
                return new DataResult<TokenDto>(ResultStatus.Error, "Email or Password wrong", null);
            }
            var token = _tokenService.CreateToken(user);
            var userRefreshToken =  _genericService.GetByIdAsync(user.Id).Result.Data;

            if (userRefreshToken ==null)
            {
                await _genericService.AddAsync(new UserRefreshTokenDto
                {
                    UserId = user.Id,
                    Code = token.RefreshToken,
                    Expiration = token.RefreshTokenExpiration
                });
            }
            else
            {
                userRefreshToken.Code=token.RefreshToken;
                userRefreshToken.Expiration=token.RefreshTokenExpiration;
            }
            await _unitOfWork.CommitAsync();
            return new DataResult<TokenDto>(ResultStatus.Success, token);
        }

        public async Task<IDataResult<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken)
        {
            var existRefreshToken =await _genericService.GetRefreshTokenAsync(refreshToken);
            if (existRefreshToken ==null)
            {
                return new DataResult<TokenDto>(ResultStatus.Error, "Refresh Token Not Found", null);

            }
            var user = await _userManager.FindByIdAsync(existRefreshToken.Data.UserId);
            if (user ==null)
            {
                return new DataResult<TokenDto>(ResultStatus.Error, "User Id Not Found", null);
            }
            var tokenDto = _tokenService.CreateToken(user);
            existRefreshToken.Data.Code = tokenDto.RefreshToken;
            existRefreshToken.Data.Expiration = tokenDto.RefreshTokenExpiration;

            await _unitOfWork.CommitAsync();
            return new DataResult<TokenDto>(ResultStatus.Success, tokenDto);
        }
    }



}
