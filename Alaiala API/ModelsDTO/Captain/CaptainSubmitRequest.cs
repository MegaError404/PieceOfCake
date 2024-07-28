using PieceOfCakeAPI.Interfaces;

namespace PieceOfCakeAPI.ModelsDTO.Captain
{
	public struct CaptainSubmitRequest : IDtoRequest
	{
		public CaptainSubmitRequest()
		{

		}

		public string SubmitLocation { get; set; } = string.Empty;
	}
}
