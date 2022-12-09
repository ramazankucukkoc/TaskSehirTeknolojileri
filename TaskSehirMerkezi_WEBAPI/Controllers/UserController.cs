using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;

namespace TaskSehirTeknolojileri_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return Ok(await _userService.CreateUserAsync(createUserDto));

        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _userService.GetUserAsync(HttpContext.User.Identity.Name));
        }
    }
}
