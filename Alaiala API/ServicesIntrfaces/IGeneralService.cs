using PieceOfCakeAPI.Models;

namespace PieceOfCakeAPI.ServicesIntrfaces
{
	public interface IGeneralService
	{
		public Task<ApiResponse<string>> GetWhatsAppSupportNumber();
		public Task<ApiResponse<string>> GetTelegramSupportAccount();
		public Task<ApiResponse<string>> GetMessengerSupportAccount();
		public Task<ApiResponse<string>> GetPhoneSupportNumber();
		public Task<ApiResponse<string>> GetAboutUsContain();
		public Task<ApiResponse<string>> GetOrderAccelerationCost();
		public Task<ApiResponse<string>> GetServiceCost();
	}
}
