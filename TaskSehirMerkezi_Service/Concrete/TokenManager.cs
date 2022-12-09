using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Core.Utilities.Jwt;
using TaskSehirTeknolojileri_Data.DataAccess.Configuration;
using TaskSehirTeknolojileri_Data.Entities.Concrete;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;
using TokenOptions = TaskSehirTeknolojileri_Data.DataAccess.Configuration.CustomTokenOptions;

namespace TaskSehirTeknolojileri_Service.Concrete
{
    public class TokenManager : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly CustomTokenOptions _tokenOptions;
        public TokenManager(UserManager<User> userManager,IOptions<CustomTokenOptions> options)
        {
            _userManager = userManager;
            _tokenOptions = options.Value;
        }
        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }
        private IEnumerable<Claim> GetClaims(User user, List<String> audinces)
        {
            var userList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            userList.AddRange(audinces.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
            return userList;
        }

        public TokenDto CreateToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenExpiration);
            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer:_tokenOptions.Issuer,
                expires:accessTokenExpiration,
                notBefore:DateTime.Now,
                claims:GetClaims(user,_tokenOptions.Audience),
                signingCredentials:signingCredentials
                );
                var handler=new JwtSecurityTokenHandler();
            var token = handler.WriteToken(securityToken);
            var tokenDto = new TokenDto
            {
                AccessTokenExpiration = accessTokenExpiration,
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                RefreshTokenExpiration = refreshTokenExpiration
            };
            return tokenDto;

        }
    }
}
