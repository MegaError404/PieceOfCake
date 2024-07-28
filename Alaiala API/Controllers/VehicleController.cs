using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.Vehicle;
using Alaiala_API.ServicesIntrfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alaiala_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IVehicleService _vehicleService;

        public VehicleController(ILogger<VehicleController> logger,IVehicleService vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        [HttpGet("GetAllVehicles")]
        public async Task<ActionResult<ApiResponse<List<GetVehicleDto>>>> GetAllGovernorates()
        {
            var response = await _vehicleService.GetAllVehicle();

            return Ok(response);
        }

        [HttpGet("GetVehicleById{id}")]
        public async Task<ActionResult<ApiResponse<GetVehicleDto>>> GetGovernorateById(int id)
        {
            var response = await _vehicleService.GetVehicleById(id);

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost("AddVehicle")]
        public async Task<ActionResult<ApiResponse<GetVehicleDto>>> AddGovernorate(AddVehicleDto addVehicleDto)
        {
            var response = await _vehicleService.AddVehicle(addVehicleDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("DeleteById")]
        public async Task<ActionResult<ApiResponse<List<GetVehicleDto>>>> DeleteById(int id)
        {
            var response = await _vehicleService.DeleteById(id);

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ApiResponse<GetVehicleDto>>> UpdateGovernorate(UpdateVehicleDto updateVehicleDto)
        {
            var response = await _vehicleService.UpdateVehicle(updateVehicleDto);

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }
    }
}
