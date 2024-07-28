using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.Captain;

namespace PieceOfCakeAPI.ServicesIntrfaces.Captain
{
	public interface ICaptainAuthenticationService
	{
		public Task<ApiResponse<CaptainRegisterResponse>> Register(CaptainRegisterRequest request);
		public Task<ApiResponse<CaptainLogInResponse>> LogIn(CaptainLogInRequest request);
	}
}
