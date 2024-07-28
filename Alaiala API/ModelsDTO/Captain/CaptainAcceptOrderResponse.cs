using PieceOfCakeAPI.Interfaces;

namespace PieceOfCakeAPI.ModelsDTO.Captain
{
	public struct CaptainAcceptOrderResponse : IDtoResponse
	{
		public CaptainAcceptOrderResponse()
		{

		}



		public enum ResponseState
		{
			OrderNotExistAnyMore = 1
		}
	}
}
