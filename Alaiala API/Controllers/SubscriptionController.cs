using Microsoft.AspNetCore.Mvc;
using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.Subscription;
using PieceOfCakeAPI.ServicesIntrfaces;

namespace PieceOfCakeAPI.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class SubscriptionController : ControllerBase
	{
		private readonly ISubscriptionService _subscriptionService;

		public SubscriptionController(ISubscriptionService subscriptionService)
		{
			_subscriptionService = subscriptionService;
		}

		[HttpGet("GetAllSubscriptions")]
		public async Task<ActionResult<ApiResponse<List<GetSubscriptionDto>>>> GetAllSubscriptions()
		{
			var response = await _subscriptionService.GetAllSubscription();

			return Ok(response);
		}

		[HttpGet("GetSubscriptionById{id}")]
		public async Task<ActionResult<ApiResponse<GetSubscriptionDto>>> GetSubscriptionById(int id)
		{
			var response = await _subscriptionService.GetSubscriptionById(id);

			if (!response.Success)
				return NotFound(response);

			return Ok(response);
		}

		[HttpPost("AddSubscription")]
		public async Task<ActionResult<ApiResponse<GetSubscriptionDto>>> AddSubscription(AddSubscriptionDto addSubscriptionDto)
		{
			var response = await _subscriptionService.AddSubscription(addSubscriptionDto);

			if (!response.Success)
				return BadRequest(response);

			return Ok(response);
		}

		[HttpPut("Update")]
		public async Task<ActionResult<ApiResponse<GetSubscriptionDto>>> UpdateSubscription(UpdateSubscriptionDto updateSubscriptionDto)
		{
			var response = await _subscriptionService.UpdateSubscription(updateSubscriptionDto);

			if (!response.Success)
				return NotFound(response);

			return Ok(response);
		}

		[HttpDelete("DeleteById")]
		public async Task<ActionResult<ApiResponse<List<GetSubscriptionDto>>>> DeleteById(int id)
		{
			var response = await _subscriptionService.DeleteById(id);

			if (!response.Success)
				return NotFound(response);

			return Ok(response);
		}


	}
}
