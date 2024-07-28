using System.Security.Claims;

namespace PieceOfCakeAPI.ModelsDTO.Captain
{
	public struct CaptainLogInRequest
	{
		public CaptainLogInRequest()
		{

		}

		public string PrimaryPhoneNumber { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;

	}
}