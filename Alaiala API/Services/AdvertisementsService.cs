using Alaiala_API.Interfaces;
using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.Advertisement;
using Alaiala_API.ServicesIntrfaces;

namespace Alaiala_API.Services
{
    public class AdvertisementsService : IRegisterService, IAdvertisementsService
	{
        private readonly ILogger<AdvertisementsService> _Logger;

        public AdvertisementsService(ILogger<AdvertisementsService> logger)
        {
            _Logger = logger;
        }

		public static void RegisterMe(IServiceCollection services)
		{
			services.AddSingleton<IAdvertisementsService, AdvertisementsService>();
		}

		public async Task<ApiResponse<List<AdvertisementsGetRespone>>> GetAllAdvertisements()
		{
			ApiResponse<List<AdvertisementsGetRespone>> response = new();

			return response;
		}

		public async Task<ApiResponse<AdvertisementsAddRespone>> AddAdvertisement(AdvertisementsAddRequest request)
		{
			ApiResponse<AdvertisementsAddRespone> response = new();

			return response;
		}

		public async Task<ApiResponse<AdvertisementsDeleteRespone>> DeleteAdvertisementById(int id)
		{
			ApiResponse<AdvertisementsDeleteRespone> response = new();

			return response;
		}
	}
}
