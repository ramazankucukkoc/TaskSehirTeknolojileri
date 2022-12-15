using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;
using TaskSehirTeknolojileri_WEBAPI.Controllers;

namespace TaskSehirMerkezi_WEBAPI.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductDto productDto)
        {
            var productDtoAdd = await _productService.AddAsync(productDto);
            if (productDtoAdd.ResultStatus == 0)
            {
                return Ok(productDtoAdd);
            }
            return BadRequest(productDtoAdd.Message);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(ProductDto productDto)
        {
            var productDtoDelete = await _productService.DeleteAsync(productDto);
            if (productDtoDelete.ResultStatus == 0)
            {
                return Ok(productDtoDelete.Data);
            }
            return BadRequest(productDtoDelete.Message);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(ProductDto productDto)
        {
            var productDtoUpdate = await _productService.UpdateAsync(productDto);
            if (productDtoUpdate.ResultStatus == 0)
            {
                return Ok(productDtoUpdate.Data);
            }
            return BadRequest(productDtoUpdate.Message);
        }
        [HttpGet]
        public async Task<IActionResult> GetProductWithCategoryList()
        {
            var productDtoList = await _productService.GetProductsWithCategory();
            if (productDtoList.ResultStatus == 0)
            {
                return Ok(productDtoList.Data);
            }
            return BadRequest(productDtoList.Message);
        }
    }
}
