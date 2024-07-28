using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.Advertisement;
using Alaiala_API.ServicesIntrfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alaiala_API.Controllers
{
    [ApiController]
	[Route("api/v1/[controller]")]
	public class AdvertisementsController : ControllerBase
	{
        private readonly ILogger<AdvertisementsController> _Logger;
		private readonly IAdvertisementsService _AdvertisementsService;
		public AdvertisementsController(ILogger<AdvertisementsController> logger, IAdvertisementsService advertisementsService)
        {
			_Logger = logger;
			_AdvertisementsService = advertisementsService;
		}

		[HttpGet("GetAllAdvertisements")]
		public async Task<ActionResult<List<AdvertisementsGetRespone>>> GetAllAdvertisements()
		{
			ApiResponse<List<AdvertisementsGetRespone>> response = await _AdvertisementsService.GetAllAdvertisements();

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpPost("AddAdvertisement{advertisement}")]
		public async Task<ActionResult> AddAdvertisement(AdvertisementsAddRequest advertisement)
		{
			ApiResponse<AdvertisementsAddRespone> response = await _AdvertisementsService.AddAdvertisement(advertisement);

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpDelete("DeleteAdvertisementById{id}")]
		public async Task<ActionResult> DeleteAdvertisementById(int id)
		{
			ApiResponse<AdvertisementsDeleteRespone> response = await _AdvertisementsService.DeleteAdvertisementById(id);

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

	}
}
