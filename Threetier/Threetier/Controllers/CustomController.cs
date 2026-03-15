using BusinessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/Custom")]
    public class CustomController:ControllerBase
    {

        private readonly ICustomerService _customerservice;
        public CustomController(ICustomerService customerservice)
        {
            _customerservice = customerservice;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            return Ok(await _customerservice.GetCustomersAsync());
        }
        [HttpPost]
        public async Task AddCustomerAsync([FromBody] CreateCustomerDTO entity)
        {
            await _customerservice.AddCustomerAsync(entity);

        }
    }
}
