using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;
using TaskSehirTeknolojileri_WEBAPI.Controllers;

namespace TaskSehirMerkezi_WEBAPI.Controllers
{

    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CustomerDto customerDto)
        {
            var customerDtoAdd = await _customerService.AddAsync(customerDto);
            if (customerDtoAdd.ResultStatus == 0)
            {
                return Ok(customerDtoAdd);
            }
            return BadRequest(customerDtoAdd.Message);
        }
        [HttpPost]
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

        [HttpGet]
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
