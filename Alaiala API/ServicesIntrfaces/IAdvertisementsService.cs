using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.Advertisement;

namespace PieceOfCakeAPI.ServicesIntrfaces
{
	public interface IAdvertisementsService
	{
		public Task<ApiResponse<List<AdvertisementsGetRespone>>> GetAllAdvertisements();
		public Task<ApiResponse<AdvertisementsAddRespone>> AddAdvertisement(AdvertisementsAddRequest request);
		public Task<ApiResponse<AdvertisementsDeleteRespone>> DeleteAdvertisementById(int id);

	}
}
