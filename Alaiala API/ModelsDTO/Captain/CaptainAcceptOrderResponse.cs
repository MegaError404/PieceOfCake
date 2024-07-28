using Alaiala_API.Interfaces;

namespace Alaiala_API.ModelsDTO.Captain
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
