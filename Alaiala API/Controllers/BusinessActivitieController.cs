using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.BusinessActivitie;
using Alaiala_API.ServicesIntrfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alaiala_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BusinessActivitieController : ControllerBase
    {
        private readonly IBusinessActivitieService _businessActivitieService;

        public BusinessActivitieController(IBusinessActivitieService businessActivitieService)
        {
            _businessActivitieService = businessActivitieService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ApiResponse<List<GetBusinessActivitieDto>>>> GetAll()
        {
            var response = await _businessActivitieService.GetAll();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }


        [HttpGet("GetByID")]
        public async Task<ActionResult<ApiResponse<List<GetBusinessActivitieDto>>>> GetById(int id)
        {
            var response = await _businessActivitieService.GetById(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ApiResponse<GetBusinessActivitieDto>>> AddBusinessActivitie(AddBusinessActivitieDto businessActivitieDto)
        {
            var response = await _businessActivitieService.AddBusinessActivitie(businessActivitieDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ApiResponse<GetBusinessActivitieDto>>> UpdateBusinessActivitie(UpdateBusinessActivitieDto updateBusinessActivitieDto)
        {
            var response = await _businessActivitieService.UpdateBusinessActivitie(updateBusinessActivitieDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("DeleteById")]
        public async Task<ActionResult<ApiResponse<GetBusinessActivitieDto>>> DeleteBYid(int id)
        {
            var response = await _businessActivitieService.DeleteById(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

    }
}
