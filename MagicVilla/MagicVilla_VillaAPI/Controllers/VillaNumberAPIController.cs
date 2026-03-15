using System.Net;
using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaNumberAPI")]
    [ApiController]
    public class VillaNumberAPIController:ControllerBase
    {
        private readonly IVillaNumberRepository _dbvillaNumber;
        private IMapper _mapper;
        private APIResponse _response;
        private readonly IVillaRespository _dbvilla;
        public VillaNumberAPIController(IVillaNumberRepository dbvillaNumbers,IMapper mapper,IVillaRespository _villa)
        {
            _dbvillaNumber = dbvillaNumbers;
            _mapper = mapper;
            this._response = new();
            _dbvilla = _villa;
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {
                IEnumerable<VillaNumber> villaNumberList = await _dbvillaNumber.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaNumberDTO>>(villaNumberList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<String>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{villaid:int}", Name="GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> GetVillaNumber(int villaid)
        {
            try
            {
                if(villaid==0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                VillaNumber villanumberdets = await _dbvillaNumber.GetAsync(u => u.VillaNo == villaid);
                if (villanumberdets == null)
                    return NotFound(_response);
                _response.Result = _mapper.Map<VillaNumberDTO>(villanumberdets);
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>>CreateVillaNumber([FromBody] VillaNumbercreateDTO createDTO)
        {
            try
            {
                if(await _dbvillaNumber.GetAsync(u=>u.VillaNo==createDTO.VillaNo)!=null)
                {
                    ModelState.AddModelError("custom error","villaNumber alredy exits");
                    return BadRequest(ModelState);

                }
                if(await _dbvilla.GetAsync(u=>u.Id==createDTO.VillaID)==null)
                {
                    ModelState.AddModelError("custom error", "villaid is invalid");
                    return BadRequest(ModelState);
                }
                if(createDTO==null)
                {
                    return BadRequest(createDTO);
                }
                VillaNumber villadets = _mapper.Map<VillaNumber>(createDTO);
                villadets.CreatedDate = DateTime.Now;
                await _dbvillaNumber.CreateAsync(villadets);
                _response.Result = _mapper.Map<VillaNumberDTO>(villadets);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVillaNumber", new { villaid = villadets.VillaNo }, _response);

            }
            catch(Exception ex)
            {
                _response.IsSucess = false;
               
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }
        }
        [HttpPut("{villaNum:int}",Name ="UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int villaNum, [FromBody]VillaNumberUpdateDTO updateDTO)
        {
            try
            {
                if(updateDTO==null || villaNum!=updateDTO.VillaNo)
                {
                    return BadRequest();

                }
                if (await _dbvilla.GetAsync(u => u.Id == updateDTO.VillaID) == null)
                {
                    ModelState.AddModelError("custom error", "villaid is invalid");
                    return BadRequest(ModelState);
                }
                VillaNumber model = _mapper.Map<VillaNumber>(updateDTO);
                 await _dbvillaNumber.UpdateAsync(model);
                
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSucess = true;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]

        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villaNum = await _dbvillaNumber.GetAsync(u => u.VillaNo == id);
                if (villaNum == null)
                {
                    return NotFound();
                }
                await _dbvillaNumber.RemoveAsync(villaNum);
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
    }
}
