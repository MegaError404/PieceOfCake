using Alaiala_API.Interfaces;
using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.Merchant;
using Alaiala_API.ServicesIntrfaces.Merchant;

namespace Alaiala_API.Services.Merchant
{
    public class MerchantOrdersService : IMerchantOrdersService, IRegisterService
    {
        public static void RegisterMe(IServiceCollection services)
        {
            services.AddScoped<IMerchantOrdersService, MerchantOrdersService>();
        }

        public Task<ApiResponse<MerchantCancelOrderResponse>> CancelOrder(MerchantCancelOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<MerchantCreateOrderResponse>> CreateOrder(MerchantCreateOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<MerchantGetOrderResponse>>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<MerchantGetOrderResponse>> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
