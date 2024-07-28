using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.Advertisement;

namespace Alaiala_API.ServicesIntrfaces
{
    public interface IAdvertisementsService
    {
        public Task<ApiResponse<List<AdvertisementsGetRespone>>> GetAllAdvertisements();
        public Task<ApiResponse<AdvertisementsAddRespone>> AddAdvertisement(AdvertisementsAddRequest request);
        public Task<ApiResponse<AdvertisementsDeleteRespone>> DeleteAdvertisementById(int id);

    }
}
