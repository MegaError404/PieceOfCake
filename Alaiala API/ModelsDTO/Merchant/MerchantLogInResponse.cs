using PieceOfCakeAPI.Interfaces;

namespace PieceOfCakeAPI.ModelsDTO.Merchant
{
	public struct MerchantLogInResponse : IDtoResponse
	{
		public MerchantLogInResponse()
		{

		}

		public string Token { get; set; } = string.Empty;
		public enum ResponseState
		{
			LoginSuccess = 1,
			InvalidPhoneNumberOrPassword = 2,
			InvalidPhoneNumber = 3,
			InvalidPassword = 4
		}
	}
}
