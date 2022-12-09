using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;


namespace TaskSehirMerkezi_WEBAPI.Controllers
{
    [Authorize(Roles = "Editor")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(CustomerDto customerDto )
        {
            var customerDtoAdd = await _customerService.AddAsync(customerDto);
            if (customerDtoAdd.ResultStatus == 0)
            {
                return Ok(customerDtoAdd);
            }
            return BadRequest(customerDtoAdd.Message);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(CustomerDto customerDto)
        {
            var customerDtoAdd = await _customerService.DeleteAsync(customerDto);
            if (customerDtoAdd.ResultStatus == 0)
            {
                return Ok(customerDtoAdd);
            }
            return BadRequest(customerDtoAdd.Message);
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(CustomerDto customerDto)
        {
            var customerDtoAdd = await _customerService.UpdateAsync(customerDto);
            if (customerDtoAdd.ResultStatus == 0)
            {
                return Ok(customerDtoAdd);
            }
            return BadRequest(customerDtoAdd.Message);
        }
        [HttpGet("customerlist")]
        public async Task<IActionResult> GetCustomerList()
        {
            var customerDtoList = await _customerService.GetAllNonDeletedAsync();
            if (customerDtoList.ResultStatus == 0)
            {
                return Ok(customerDtoList.Data);
            }
            return BadRequest(customerDtoList.Message);
        }
    }
}
