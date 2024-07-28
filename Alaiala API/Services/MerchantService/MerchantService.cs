using Alaiala_API.Interfaces;
using Alaiala_API.ServicesIntrfaces.Merchant;

namespace Alaiala_API.Services.Merchant
{
    public class MerchantService : IRegisterService, IMerchantService
    {
        public static void RegisterMe(IServiceCollection services)
        {
            services.AddScoped<IMerchantService, MerchantService>();
        }
    }
}
