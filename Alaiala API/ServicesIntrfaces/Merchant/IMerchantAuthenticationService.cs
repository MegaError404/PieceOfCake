using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.Merchant;

namespace Alaiala_API.ServicesIntrfaces.Merchant
{
    public interface IMerchantAuthenticationService
    {
        public Task<ApiResponse<string>> Register(MerchantRegisterRequest request);
        public Task<ApiResponse<string>> LogIn(MerchantLogInRequest request);

    }
}
