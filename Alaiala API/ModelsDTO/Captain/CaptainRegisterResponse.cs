using Alaiala_API.Interfaces;

namespace Alaiala_API.ModelsDTO.Captain
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
