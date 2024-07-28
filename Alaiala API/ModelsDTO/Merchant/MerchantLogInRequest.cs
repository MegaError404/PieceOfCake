using PieceOfCakeAPI.Interfaces;
using System.Security.Claims;

namespace PieceOfCakeAPI.ModelsDTO.Merchant
{
	public struct MerchantLogInRequest : IDtoRequest
	{
		public MerchantLogInRequest()
		{

		}

		public string PrimaryPhoneNumber { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;

		public List<Claim> GetClaims()
		{
			return new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, PrimaryPhoneNumber)
			};
		}
	}
}
