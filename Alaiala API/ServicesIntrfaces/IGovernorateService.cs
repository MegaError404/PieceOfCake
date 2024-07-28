using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.Governorate;

namespace PieceOfCakeAPI.ServicesIntrfaces
{
	public interface IGovernorateService
	{
		public Task<ApiResponse<List<GovernoratesGetResponse>>> GetAllGovernorates();
		public Task<ApiResponse<GovernoratesGetResponse>> GetGovernorateById(int id);
		public Task<ApiResponse<GovernoratesAddResponse>> AddGovernorate(GovernoratesAddRequest governorate);
		public Task<ApiResponse<GovernoratesGetResponse>> UpdateGovernorate(UpdateGovernorate updateGovernorate);
		public Task<ApiResponse<List<GovernoratesGetResponse>>> DeleteById(int id);
	}
}
