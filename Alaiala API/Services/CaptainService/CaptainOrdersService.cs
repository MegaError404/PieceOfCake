using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PieceOfCakeAPI.Data;
using PieceOfCakeAPI.Enumerations;
using PieceOfCakeAPI.Interfaces;
using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.Models.Orders;
using PieceOfCakeAPI.ModelsDTO.Captain;
using PieceOfCakeAPI.ServicesIntrfaces.Captain;

namespace PieceOfCakeAPI.Services.CaptainService
{
	public class CaptainOrdersService : IRegisterService, ICaptainOrdersService
	{
		private readonly DataContext _DataContext;
		ILogger<CaptainOrdersService> _Logger;
		IMapper _Mapper;

		public CaptainOrdersService(DataContext dataContext, ILogger<CaptainOrdersService> logger, IMapper mapper)
		{
			_Logger = logger;
			_Mapper = mapper;
			_DataContext = dataContext;
		}

		public static void RegisterMe(IServiceCollection services)
		{
			services.AddScoped<ICaptainOrdersService, CaptainOrdersService>();
		}

		public async Task<ApiResponse<CaptainAcceptOrderResponse>> AcceptOrder(CaptainAcceptOrderRequest request)
		{
			ApiResponse<CaptainAcceptOrderResponse> responese = new();

			try
			{
				AcceptedOrders acceptedOrders = new();

				var newOrders = await _DataContext.NewOrders.FirstOrDefaultAsync(o => o.GUID == request.OrderGUID);

				if (newOrders is null)
				{
					var redirectedOrder = await _DataContext.RedirectedOrders.FirstOrDefaultAsync(o => o.GUID == request.OrderGUID);

					if (redirectedOrder is null)
					{
						responese.Message = CaptainAcceptOrderResponse.ResponseState.OrderNotExistAnyMore.ToString();
						responese.Success = false;
						return responese;
					}
					else
					{
						acceptedOrders.GUID = redirectedOrder.GUID;
						acceptedOrders.OrderType = redirectedOrder.OrderType;
						acceptedOrders.CreatingDateTime = redirectedOrder.CreatingDateTime;
						acceptedOrders.OrderCost = redirectedOrder.OrderCost;
						acceptedOrders.DeliveringCost = redirectedOrder.DeliveringCost;
						acceptedOrders.ServiceCost = redirectedOrder.ServiceCost;
						acceptedOrders.OverLoadCosts = redirectedOrder.OverLoadCosts;

					}
				}
				else
				{
					acceptedOrders.GUID = newOrders.GUID;
					acceptedOrders.OrderType = newOrders.OrderType;
					acceptedOrders.CreatingDateTime = newOrders.CreatingDateTime;
					acceptedOrders.OrderCost = newOrders.OrderCost;
					acceptedOrders.DeliveringCost = newOrders.DeliveringCost;
					acceptedOrders.ServiceCost = newOrders.ServiceCost;
					acceptedOrders.OverLoadCosts = newOrders.OverLoadCosts;

				}

				AcceptedOrders? maxOrder = await _DataContext.AcceptedOrders.OrderBy(order => order.Number).FirstOrDefaultAsync();

				if (maxOrder is null)
					maxOrder = new();

				acceptedOrders.GUID = Guid.NewGuid();
				acceptedOrders.Number = (Convert.ToInt64(maxOrder.Number) + 1).ToString();
				acceptedOrders.PaymentStatus = PaymentCases.Unpaid;
				acceptedOrders.AcceptingDateTime = DateTime.Now;

			}
			catch (Exception)
			{
				throw;
			}

			return responese;
		}

		public async Task<ApiResponse<CaptainCancelOrderResponse>> CancelOrder(CaptainCancelOrderRequest request)
		{
			throw new NotImplementedException();
		}

		public async Task<ApiResponse<CaptainDelivereOrderResponse>> DelivereOrder(CaptainDelivereOrderRequest request)
		{
			throw new NotImplementedException();
		}

		public async Task<ApiResponse<List<CaptainGetOrderResponse>>> GetAllOrders()
		{
			ApiResponse<List<CaptainGetOrderResponse>> response = new();

			return response;
		}

		public async Task<ApiResponse<CaptainGetOrderResponse>> GetOrderById(int id)
		{
			ApiResponse<CaptainGetOrderResponse> response = new();

			return response;
		}

		public async Task<ApiResponse<CaptainRedirectOrderResponse>> RedirectOrder(CaptainRedirectOrderRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
