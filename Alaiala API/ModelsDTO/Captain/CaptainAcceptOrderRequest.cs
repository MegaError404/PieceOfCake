using PieceOfCakeAPI.Interfaces;

namespace PieceOfCakeAPI.ModelsDTO.Captain
{
	public struct CaptainAcceptOrderRequest : IDtoRequest
	{
		public CaptainAcceptOrderRequest()
		{

		}

		public string Token { get; set; } = string.Empty;
		public Guid OrderGUID { get; set; } = Guid.Empty;
	}
}
