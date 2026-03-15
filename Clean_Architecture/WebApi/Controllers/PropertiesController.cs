using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Properties.Commands;
using Application.Features.Properties.Queries;
using Application.Models;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly ISender _mediatrSender;
        public PropertiesController(ISender mediatrSender)
        {
            _mediatrSender = mediatrSender;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddNewProperty([FromBody] NewProperty newpropertyRequest)
        {
            bool isSuccessful = await _mediatrSender.Send(new CreatePropertyRequest(newpropertyRequest));
            if(isSuccessful)
            {
                return Ok("Property created successfully");
            }
            return BadRequest("Failed to cerate prperty ");
        }
        [HttpPut("update")]
        public async Task<IActionResult>UpdateProperty([FromBody]UpdateProperty updateproperty)
        {
            bool issuccessful=await _mediatrSender.Send(new UpdatePropertyRequest(updateproperty));
            if (issuccessful)
            {
                return Ok("Property updated successfully");
            }
            return NotFound("property does nit exist");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetPropertyById(int id)
        {
          PropertyDto p  = await _mediatrSender.Send(new GetPropertyById(id));
           
            if (p != null)
             return Ok(p);
            return NotFound("Property doesnot exist");
        }
        [HttpGet("all")]
        public async Task<IActionResult>GetProperties()
        {
            List<PropertyDto>propertydtos=await _mediatrSender.Send(new GetPropertiesRequest());
            if(propertydtos != null)
            return Ok(propertydtos);
            return NotFound("No properties were found");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            bool isSuccesful=await _mediatrSender.Send(new DeletePropertyRequest(id));
            if(isSuccesful)
            {
                return Ok("Property deletd successfully");  
            }
            return NotFound("property doesnot exist");
        }
    }
}
