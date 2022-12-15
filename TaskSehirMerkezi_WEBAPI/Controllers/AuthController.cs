using Microsoft.AspNetCore.Mvc;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;

namespace TaskSehirTeknolojileri_WEBAPI.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authenticationService;

        public AuthController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserLoginDto loginDto)
        {
            var userToLogin = await _authenticationService.LoginAsync(loginDto);
            if (userToLogin.ResultStatus!=0)
            {
                return BadRequest(userToLogin.Message);
            }
            var result =await _authenticationService.CreateAccessTokenAsync(userToLogin.Data);
            if (result.ResultStatus==0)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);   
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(UserRegisterDto registerDto)
        {
            var userExists = await _authenticationService.UserExists(registerDto.Email);
            if (userExists.ResultStatus ==0)
            {
                return BadRequest(userExists.Message);
            }
            var registerResult = await _authenticationService.RegisterAsync(registerDto,registerDto.Password);
            var result = await _authenticationService.CreateAccessTokenAsync(registerResult.Data);
            if (result.ResultStatus == 0)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }



    }
}
