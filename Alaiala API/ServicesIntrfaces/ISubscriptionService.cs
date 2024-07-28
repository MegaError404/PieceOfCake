using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.Subscription;

namespace PieceOfCakeAPI.ServicesIntrfaces
{
	public interface ISubscriptionService
	{
		Task<ApiResponse<List<GetSubscriptionDto>>> GetAllSubscription();
		Task<ApiResponse<GetSubscriptionDto>> GetSubscriptionById(int id);
		Task<ApiResponse<GetSubscriptionDto>> AddSubscription(AddSubscriptionDto addSubscriptionDto);
		Task<ApiResponse<GetSubscriptionDto>> UpdateSubscription(UpdateSubscriptionDto updateSubscriptionDto);
		Task<ApiResponse<List<GetSubscriptionDto>>> DeleteById(int id);
	}
}
