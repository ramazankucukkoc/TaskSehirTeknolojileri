using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;

namespace TaskSehirMerkezi_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(CategoryDto categoryDto)
        {
            var categoryDtoAdd = await _categoryService.AddAsync(categoryDto);
            if (categoryDtoAdd.ResultStatus == 0)
            {
                return Ok(categoryDtoAdd.Data);
            }
            return BadRequest(categoryDtoAdd.Message);
        }

    }
}
