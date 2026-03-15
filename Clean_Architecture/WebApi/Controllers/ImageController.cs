using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Images.Commands;
using Application.Features.Images.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController :ControllerBase
    {
        private readonly ISender _mediatrSender;
        public ImageController(ISender mediatrsender)
        {
            _mediatrSender = mediatrsender;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddNewImage([FromBody] NewImage newImage)
        {
            bool issuccessful = await _mediatrSender.Send(new CreateImageRequest(newImage));
            if (issuccessful)
            {
                return Ok("Image created");
            }
            return BadRequest("failed to create image");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImage(UpdateImage updateimage)
        {
            bool issuccesful = await _mediatrSender.Send(new UpdateImageRequest(updateimage));
            if (issuccesful)
            {
                return Ok("updated succesfully");
            }
            return NotFound("update failed");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            bool issucceesful = await _mediatrSender.Send(new DeleteImageRequest(id));
            if (issucceesful)
            {
              
                    return Ok("Image deletd successfully");
               

            }
            return NotFound("Image doesnot exist");
        }
        [HttpGet("{id}")]
        public  async Task<IActionResult>GetImage(int id)
        {
            ImageDto image=await _mediatrSender.Send(new GetImageById(id));
            if(image!= null)
            {
                return Ok(image);
            }
            return NotFound("Image doesnot exist");
        }
        [HttpGet("all")]
        public async Task<IActionResult>GetImages()
        {
            List<ImageDto> images = await _mediatrSender.Send(new GetAllRequest());
            if(images!= null)
            {
                return Ok(images);  
            }
            return NotFound("No image is found");
        }

    }
}
