using Alaiala_API.Interfaces;

namespace Alaiala_API.ModelsDTO.Captain
{
    public struct CaptainSubmitRequest : IDtoRequest
    {
        public CaptainSubmitRequest()
        {

        }

        public string SubmitLocation { get; set; } = string.Empty;
    }
}
