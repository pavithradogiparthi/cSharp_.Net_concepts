using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Global_exception_Handling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            throw new Exception("Test Exception");
            return Ok(new[] { 1, 2, 3 });
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById()
        {
            throw new NotImplementedException("Not implemented this method");
            
        }
    }

}
