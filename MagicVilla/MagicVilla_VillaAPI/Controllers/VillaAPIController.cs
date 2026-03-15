using System.Net;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Controllers
{ 
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController:ControllerBase

    {
        private readonly IRepository<Villa> _dbvilla;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public VillaAPIController(IVillaRespository dbvilla,IMapper mapper)
        {
            _dbvilla=dbvilla;
            _mapper = mapper;
            this._response = new();
        }
      
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillas() {
            try
            {
                IEnumerable<Villa> villaList = await _dbvilla.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaDTO>>(villaList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id:int}",Name ="GetVilla")]
        //[ProducesResponseType(200,Type=typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public  async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response); ;
                }
                var villa = await _dbvilla.GetAsync(u => u.Id == id);
                if (villa == null)
                    return NotFound(_response);
                _response.Result = _mapper.Map<VillaDTO>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task< ActionResult<APIResponse>>CreateVilla([FromBody]VillaCreateDTO createDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            try
            {
                if (await _dbvilla.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Custom error ", "Villa alredy Exists");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                Villa villa = _mapper.Map<Villa>(createDTO);
                await _dbvilla.CreateAsync(villa);
                _response.Result = _mapper.Map<VillaDTO>(villa);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVilla", new { id = villa.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id:int}",Name ="DeleteVilla")]
  
        public async Task<ActionResult<APIResponse>>DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villa = await _dbvilla.GetAsync(u => u.Id == id);
                if (villa == null)
                {
                    return NotFound();
                }
                await _dbvilla.RemoveAsync(villa);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSucess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[HttpPut("{id:int}", Name = "UpdateVilla")]
        //public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        if (updateDTO == null || id != updateDTO.Id)
        //        {
        //            return BadRequest();
        //        }

        //        Villa model = _mapper.Map<Villa>(updateDTO);
        //        await _dbvilla.UpdateAsync(model);
        //        _response.StatusCode = HttpStatusCode.NoContent;
        //        _response.IsSucess = true;
        //        return Ok(_response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSucess = false;
        //        _response.ErrorMessages = new List<string>() { ex.ToString() };
        //    }
        //    return _response;


        //}
        //[HttpPatch("{id:int}",Name="UpdatePatialVilla")]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public   async Task<ActionResult> UpdatePartialVilla(int id,JsonPatchDocument<VillaUpdateDTO>patchDTO)
        //{
        //    if(patchDTO==null || id==0 )
        //    {
        //        return BadRequest();
        //    }
        //    var villa =  _dbvilla.GetAsync(u => u.Id == id,tracked:false);
        //    VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
        //    //VillaUpdateDTO villaDTO = new()
        //    //{
        //    //    Amenity = villa.Amenity,
        //    //    Details = villa.Details,
        //    //    Id = villa.Id,
        //    //    ImageUrl = villa.ImageUrl,
        //    //    Name = villa.Name,
        //    //    Occupancy = villa.Occupancy,
        //    //    Rate = villa.Rate,
        //    //    sqft = villa.Sqft
        //    //};
        //    if (villa==null)
        //    {
        //        return BadRequest();
        //    }
        //    patchDTO.ApplyTo(villaDTO, ModelState);
        //    Villa model = _mapper.Map<Villa>(villaDTO);

        //     await _dbvilla.UpdateAsync(model);




        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    return NoContent();

        //}
    }
}
