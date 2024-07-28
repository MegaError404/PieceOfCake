using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.Captain;

namespace Alaiala_API.ServicesIntrfaces.Captain
{
    public interface ICaptainAuthenticationService
    {
        public Task<ApiResponse<CaptainRegisterResponse>> Register(CaptainRegisterRequest request);
        public Task<ApiResponse<CaptainLogInResponse>> LogIn(CaptainLogInRequest request);
    }
}
