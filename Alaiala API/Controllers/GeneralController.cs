using Alaiala_API.Models;
using Alaiala_API.ServicesIntrfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alaiala_API.Controllers
{
    [ApiController]
	[Route("api/v1/[controller]")]
	public class GeneralController : ControllerBase
	{
		private readonly ILogger<GeneralController> _Logger;
		private readonly IGeneralService _GeneralService;

		public GeneralController(ILogger<GeneralController> logger, IGeneralService generalService)
        {
			_Logger = logger;
			_GeneralService = generalService;
        }

		[HttpGet("GetWhatsAppSupportNumber")]
		public async Task<ActionResult<string>> GetWhatsAppSupportNumber()
		{
			ApiResponse<string> response = await _GeneralService.GetWhatsAppSupportNumber();

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpGet("GetTelegramSupportAccount")]
		public async Task<ActionResult<string>> GetTelegramSupportAccount()
		{
			ApiResponse<string> response = await _GeneralService.GetTelegramSupportAccount();

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpGet("GetMessengerSupportAccount")]
		public async Task<ActionResult<string>> GetMessengerSupportAccount()
		{
			ApiResponse<string> response = await _GeneralService.GetMessengerSupportAccount();

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpGet("GetPhoneSupportNumber")]
		public async Task<ActionResult<string>> GetPhoneSupportNumber()
		{
			ApiResponse<string> response = await _GeneralService.GetPhoneSupportNumber();

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpGet("GetAboutUsContain")]
		public async Task<ActionResult<string>> GetAboutUsContain()
		{
			ApiResponse<string> response = await _GeneralService.GetAboutUsContain();

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpGet("GetOrderAccelerationCost")]
		public async Task<ActionResult<string>> GetOrderAccelerationCost()
		{
			ApiResponse<string> response = await _GeneralService.GetOrderAccelerationCost();

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpGet("GetServiceCost")]
		public async Task<ActionResult<string>> GetServiceCost()
		{
			ApiResponse<string> response = await _GeneralService.GetServiceCost();

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

	}
}
