using PieceOfCakeAPI.Interfaces;

namespace PieceOfCakeAPI.ModelsDTO.Captain
{
	public struct CaptainRegisterResponse : IDtoResponse
	{
		public CaptainRegisterResponse()
		{
		}

		public enum ResponseState
		{
			CaptainAlreadyExsist = 1,
			GovernorateNotExsist = 2
		}
	}
}
