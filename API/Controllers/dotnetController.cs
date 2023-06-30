using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_CRUD.Infrastructure.Interfaces;
using Dotnet_CRUD.Shared.Dtos;
using Dotnet_CRUD.Shared.ResponseDataHandler;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_CRUD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class dotnetController : ControllerBase
    {
        public readonly ICharacterRepository _unitOfWork;
        private readonly IResponseHandler _responseHandler;

        public dotnetController(ICharacterRepository unitOfWork, IResponseHandler responseHandler)
        {
            _unitOfWork = unitOfWork;
            _responseHandler = responseHandler;
        }


        [HttpGet()]
        public async Task<IActionResult> GetAllCharacterAsync()
        {
            try
            {

                var results = await _unitOfWork.getAllCharacterList();
                if (results.v_rescode == "201")
                {
                    var response = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R201);
                    return Ok(new { code = response.code, message = response.message, data = results.v_data });
                }

                var res = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R000);
                return StatusCode(500, new { code = res.code, message = res.message, description = results.v_resmessage });

            }
            catch (Exception ex)
            {
                var response = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R001);
                return BadRequest(new { code = response.code, message = response.message, description = ex.Message });
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddCharacter([FromBody] AddCharacterDto character)
        {
            try
            {

                var results = await _unitOfWork.addCharacter(character);
                if (results.v_rescode == "201")
                {
                    var response = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R201);
                    return Ok(new { code = response.code, message = response.message, data = results.v_data });
                }

                var res = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R000);
                return StatusCode(500, new { code = res.code, message = res.message, description = results.v_resmessage });

            }
            catch (Exception ex)
            {
                var response = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R001);
                return BadRequest(new { code = response.code, message = response.message, description = ex.Message });
            }
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateCharacter([FromBody] UpdateCharacterDto character)
        {
            try
            {

                var results = await _unitOfWork.updateCharacter(character);
                if (results.v_rescode == "201")
                {
                    var response = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R201);
                    return Ok(new { code = response.code, message = response.message, data = results.v_data });
                }
                if (results.v_rescode == "003")
                {
                    var response = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R003);
                    return Ok(new { code = response.code, message = response.message, description = results.v_resmessage });
                }

                var res = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R000);
                return StatusCode(500, new { code = res.code, message = res.message, description = results.v_resmessage });

            }
            catch (Exception ex)
            {
                var response = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R001);
                return BadRequest(new { code = response.code, message = response.message, description = ex.Message });
            }
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteCharacter([FromRoute] string ID)
        {
            try
            {

                var results = await _unitOfWork.deleteCharacter(ID);
                if (results.v_rescode == "201")
                {
                    var response = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R201);
                    return Ok(new { code = response.code, message = response.message, data = results.v_data });
                }
                if (results.v_rescode == "003")
                {
                    var response = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R003);
                    return Ok(new { code = response.code, message = response.message, description = results.v_resmessage });
                }

                var res = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R000);
                return StatusCode(500, new { code = res.code, message = res.message, description = results.v_resmessage });

            }
            catch (Exception ex)
            {
                var response = _responseHandler.GetResponse<ResponseData>(ResponseEnum.R001);
                return BadRequest(new { code = response.code, message = response.message, description = ex.Message });
            }
        }




    }
}