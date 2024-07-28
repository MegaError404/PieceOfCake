using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.Captain;

namespace PieceOfCakeAPI.ServicesIntrfaces.Captain
{
	public interface ICaptainOrdersService
	{
		public Task<ApiResponse<List<CaptainGetOrderResponse>>> GetAllOrders();
		public Task<ApiResponse<CaptainGetOrderResponse>> GetOrderById(int id);
		public Task<ApiResponse<CaptainAcceptOrderResponse>> AcceptOrder(CaptainAcceptOrderRequest request);
		public Task<ApiResponse<CaptainCancelOrderResponse>> CancelOrder(CaptainCancelOrderRequest request);
		public Task<ApiResponse<CaptainRedirectOrderResponse>> RedirectOrder(CaptainRedirectOrderRequest request);
		public Task<ApiResponse<CaptainDelivereOrderResponse>> DelivereOrder(CaptainDelivereOrderRequest request);

	}
}
