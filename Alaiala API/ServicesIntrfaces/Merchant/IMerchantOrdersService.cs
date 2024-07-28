using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.Merchant;

namespace PieceOfCakeAPI.ServicesIntrfaces.Merchant
{
	public interface IMerchantOrdersService
	{
		public Task<ApiResponse<List<MerchantGetOrderResponse>>> GetAllOrders();
		public Task<ApiResponse<MerchantGetOrderResponse>> GetOrderById(int id);
		public Task<ApiResponse<MerchantCreateOrderResponse>> CreateOrder(MerchantCreateOrderRequest request);
		public Task<ApiResponse<MerchantCancelOrderResponse>> CancelOrder(MerchantCancelOrderRequest request);
	}
}
