using Microsoft.AspNetCore.Mvc;
using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.Governorate;
using PieceOfCakeAPI.ServicesIntrfaces;

namespace PieceOfCakeAPI.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class GovernorateController : ControllerBase
	{
		private readonly ILogger<GovernorateController> _Logger;
		private readonly IGovernorateService _governorateService;

		public GovernorateController(ILogger<GovernorateController> logger, IGovernorateService governorateService)
		{
			_Logger = logger;
			_governorateService = governorateService;
		}

		[HttpGet("GetAllGovernorates")]
		public async Task<ActionResult<ApiResponse<List<GovernoratesGetResponse>>>> GetAllGovernorates()
		{
			var response = await _governorateService.GetAllGovernorates();

			return Ok(response);
		}

		[HttpGet("GetGovernorateById{id}")]
		public async Task<ActionResult<ApiResponse<GovernoratesGetResponse>>> GetGovernorateById(int id)
		{
			var response = await _governorateService.GetGovernorateById(id);

			if (!response.Success)
				return NotFound(response);

			return Ok(response);
		}

		[HttpPost("AddGovernorate")]
		public async Task<ActionResult<ApiResponse<GovernoratesAddResponse>>> AddGovernorate(GovernoratesAddRequest governorate)
		{
			var response = await _governorateService.AddGovernorate(governorate);

			if (!response.Success)
				return BadRequest(response);

			return Ok(response);
		}
		[HttpDelete("DeleteById")]
		public async Task<ActionResult<ApiResponse<List<GovernoratesGetResponse>>>> DeleteById(int id)
		{
			var response = await _governorateService.DeleteById(id);

			if (!response.Success)
				return NotFound(response);

			return Ok(response);
		}
		[HttpPut("Update")]
		public async Task<ActionResult<ApiResponse<GovernoratesGetResponse>>> UpdateGovernorate(UpdateGovernorate updateGovernorate)
		{
			var response = await _governorateService.UpdateGovernorate(updateGovernorate);

			if (!response.Success)
				return NotFound(response);

			return Ok(response);
		}
	}
}
