using Alaiala_API.Helper;
using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.Captain;
using Alaiala_API.ServicesIntrfaces.Captain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alaiala_API.Controllers
{
	[Authorize(AuthenticationSchemes = AuthenticationHelper.AppSchemas.Captain)]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CaptainController : ControllerBase
    {
        private readonly ILogger<CaptainController> _Logger;
        private readonly ICaptainService _CaptainService;
        private readonly ICaptainAuthenticationService _captainAuthenticationService;
        private readonly ICaptainOrdersService _CaptainOrdersService;

        public CaptainController(ILogger<CaptainController> logger, ICaptainService captainService, ICaptainAuthenticationService captainAuthenticationService, ICaptainOrdersService captainOrdersService)
        {
            _Logger = logger;
			_CaptainService = captainService;
            _captainAuthenticationService = captainAuthenticationService;
			_CaptainOrdersService = captainOrdersService;
		}

		[AllowAnonymous]
		[HttpPost("Register")]
        public async Task<ActionResult<CaptainRegisterResponse>> Register(CaptainRegisterRequest request)
        {
			ApiResponse<CaptainRegisterResponse> response = await _captainAuthenticationService.Register(request);

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[AllowAnonymous]
		[HttpPost("LogIn")]
        public async Task<ActionResult<CaptainLogInResponse>> LogIn(CaptainLogInRequest request)
        {
			ApiResponse<CaptainLogInResponse> response = await _captainAuthenticationService.LogIn(request);

            if (!response.Success) 
            {
                Response.Headers.Append("ErrorMessage", response.Message);
                return BadRequest();
			}

			return Ok(response.Data);
        }

		[HttpGet("GetAllOrders")]
		public async Task<ActionResult<List<CaptainGetOrderResponse>>> GetAllOrders()
		{
			ApiResponse<List<CaptainGetOrderResponse>> response = await _CaptainOrdersService.GetAllOrders();

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpGet("GetOrderById{id}")]
		public async Task<ActionResult<CaptainGetOrderResponse>> GetOrderById(int Id)
		{
			ApiResponse<CaptainGetOrderResponse> response = await _CaptainOrdersService.GetOrderById(Id);

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpPost("AcceptOrder{request}")]
		public async Task<ActionResult<CaptainAcceptOrderResponse>> AcceptOrder(CaptainAcceptOrderRequest request)
		{
			ApiResponse<CaptainAcceptOrderResponse> response = await _CaptainOrdersService.AcceptOrder(request);

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpPost("CancelOrder{request}")]
		public async Task<ActionResult<CaptainCancelOrderResponse>> CancelOrder(CaptainCancelOrderRequest request)
		{
			ApiResponse<CaptainCancelOrderResponse> response = await _CaptainOrdersService.CancelOrder(request);

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpPost("RedirectOrder{request}")]
		public async Task<ActionResult<CaptainCancelOrderResponse>> RedirectOrder(CaptainCancelOrderRequest request)
		{
			ApiResponse<CaptainCancelOrderResponse> response = await _CaptainOrdersService.CancelOrder(request);

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}

		[HttpPost("DelivereOrder{request}")]
		public async Task<ActionResult<CaptainDelivereOrderResponse>> DelivereOrder(CaptainDelivereOrderRequest request)
		{
			ApiResponse<CaptainDelivereOrderResponse> response = await _CaptainOrdersService.DelivereOrder(request);

			if (!response.Success)
			{
				Response.Headers.Append("ErrorMessage", response.Message);
				return BadRequest();
			}

			return Ok(response.Data);
		}
	}
}
