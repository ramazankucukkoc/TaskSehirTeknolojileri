using Microsoft.AspNetCore.Mvc;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;
using TaskSehirTeknolojileri_WEBAPI.Controllers;

namespace TaskSehirMerkezi_WEBAPI.Controllers
{
    public class CategoriesController : BaseApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
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
