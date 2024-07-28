using PieceOfCakeAPI.Interfaces;
using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.Merchant;
using PieceOfCakeAPI.ServicesIntrfaces.Merchant;

namespace PieceOfCakeAPI.Services.MerchantService
{
	public class MerchantOrdersService : IMerchantOrdersService, IRegisterService
	{
		public static void RegisterMe(IServiceCollection services)
		{
			services.AddScoped<IMerchantOrdersService, MerchantOrdersService>();
		}

		public Task<ApiResponse<MerchantCancelOrderResponse>> CancelOrder(MerchantCancelOrderRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ApiResponse<MerchantCreateOrderResponse>> CreateOrder(MerchantCreateOrderRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ApiResponse<List<MerchantGetOrderResponse>>> GetAllOrders()
		{
			throw new NotImplementedException();
		}

		public Task<ApiResponse<MerchantGetOrderResponse>> GetOrderById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
