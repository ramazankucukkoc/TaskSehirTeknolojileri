using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;

namespace TaskSehirTeknolojileri_WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticetionService _authenticationService;

        public AuthController(IAuthenticetionService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenAsync(LoginDto loginDto)
        {
            var result = await _authenticationService.CreateTokenAsync(loginDto);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshTokenAsync(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authenticationService.CreateTokenByRefreshTokenAsync(refreshTokenDto.RefreshToken);
            return Ok(result);
        }

    }
}
