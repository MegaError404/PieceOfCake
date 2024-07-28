using System.Security.Claims;

namespace Alaiala_API.ModelsDTO.Captain
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