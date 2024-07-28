using Microsoft.AspNetCore.Mvc;
using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.Merchant;
using PieceOfCakeAPI.ServicesIntrfaces.Merchant;

namespace PieceOfCakeAPI.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class MerchantController : ControllerBase
	{
		private readonly ILogger<MerchantController> _logger;
		private readonly IMerchantAuthenticationService _merchantAuthenticationService;
		private readonly IMerchantOrdersService _merchantOrdersService;

		public MerchantController(ILogger<MerchantController> logger, IMerchantAuthenticationService merchantAuthenticationService, IMerchantOrdersService merchantOrdersService)
		{
			_logger = logger;
			_merchantAuthenticationService = merchantAuthenticationService;
			_merchantOrdersService = merchantOrdersService;
		}

		[HttpPost("Register")]
		public async Task<ActionResult<ApiResponse<string>>> MerchantRegister(MerchantRegisterRequest request)
		{
			var response = await _merchantAuthenticationService.Register(request);

			if (!response.Success)
				return BadRequest(response);

			return Ok(response);
		}

		[HttpPost("LogIn")]
		public async Task<ActionResult<ApiResponse<string>>> MerchantLogIn(MerchantLogInRequest request)
		{
			var response = await _merchantAuthenticationService.LogIn(request);

			if (!response.Success)
				return BadRequest(response);

			return Ok(response);
		}

		[HttpGet("GetAllOrders")]
		public async Task<ActionResult<List<MerchantGetOrderResponse>>> GetAllOrders()
		{
			ApiResponse<List<MerchantGetOrderResponse>> response = await _merchantOrdersService.GetAllOrders();

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpGet("GetOrderById")]
		public async Task<ActionResult<MerchantGetOrderResponse>> GetOrderById(int id)
		{
			ApiResponse<MerchantGetOrderResponse> response = await _merchantOrdersService.GetOrderById(id);

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpPut("CreateOrder")]
		public async Task<ActionResult<MerchantCreateOrderResponse>> CreateOrder(MerchantCreateOrderRequest request)
		{
			ApiResponse<MerchantCreateOrderResponse> response = await _merchantOrdersService.CreateOrder(request);

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpPost("CancelOrder")]
		public async Task<ActionResult<MerchantCancelOrderResponse>> CancelOrder(MerchantCancelOrderRequest request)
		{
			ApiResponse<MerchantCancelOrderResponse> response = await _merchantOrdersService.CancelOrder(request);

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}
	}
}
