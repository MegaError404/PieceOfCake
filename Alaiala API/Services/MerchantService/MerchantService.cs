using PieceOfCakeAPI.Interfaces;
using PieceOfCakeAPI.ServicesIntrfaces.Merchant;

namespace PieceOfCakeAPI.Services.MerchantService
{
	public class MerchantService : IRegisterService, IMerchantService
	{
		public static void RegisterMe(IServiceCollection services)
		{
			services.AddScoped<IMerchantService, MerchantService>();
		}
	}
}
