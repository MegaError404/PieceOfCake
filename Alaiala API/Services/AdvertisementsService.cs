using PieceOfCakeAPI.Interfaces;
using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.Advertisement;
using PieceOfCakeAPI.ServicesIntrfaces;

namespace PieceOfCakeAPI.Services
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
