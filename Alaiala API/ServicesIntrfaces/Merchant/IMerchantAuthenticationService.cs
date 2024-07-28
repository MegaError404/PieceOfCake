using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.Merchant;

namespace PieceOfCakeAPI.ServicesIntrfaces.Merchant
{
	public interface IMerchantAuthenticationService
	{
		public Task<ApiResponse<string>> Register(MerchantRegisterRequest request);
		public Task<ApiResponse<string>> LogIn(MerchantLogInRequest request);

	}
}
