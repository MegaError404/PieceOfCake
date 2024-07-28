using Alaiala_API.Interfaces;
using Alaiala_API.Models;
using Alaiala_API.ServicesIntrfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Alaiala_API.Services
{
    public class GeneralService : IRegisterService , IGeneralService
	{

        private ILogger<GeneralService> _Logger;
        public GeneralService(ILogger<GeneralService> logger)
        {
            _Logger = logger;
        }

		public static void RegisterMe(IServiceCollection services)
		{
			services.AddSingleton<IGeneralService, GeneralService>();
		}

		public async Task<ApiResponse<string>> GetAboutUsContain()
		{
			ApiResponse<string> apiResponse = new();

			return apiResponse;
		}

		public async Task<ApiResponse<string>> GetMessengerSupportAccount()
		{
			ApiResponse<string> apiResponse = new();

			return apiResponse;
		}

		public async Task<ApiResponse<string>> GetOrderAccelerationCost()
		{
			ApiResponse<string> apiResponse = new();

			return apiResponse;
		}

		public async Task<ApiResponse<string>> GetPhoneSupportNumber()
		{
			ApiResponse<string> apiResponse = new();

			return apiResponse;
		}

		public async Task<ApiResponse<string>> GetServiceCost()
		{
			ApiResponse<string> apiResponse = new();

			return apiResponse;
		}

		public async Task<ApiResponse<string>> GetTelegramSupportAccount()
		{
			ApiResponse<string> apiResponse = new();

			return apiResponse;
		}

		public async Task<ApiResponse<string>> GetWhatsAppSupportNumber()
		{
			ApiResponse<string> apiResponse = new();

			return apiResponse;
		}
	}
}
