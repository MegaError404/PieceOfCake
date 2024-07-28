using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.BusinessActivitie;

namespace PieceOfCakeAPI.ServicesIntrfaces
{
	public interface IBusinessActivitieService
	{
		Task<ApiResponse<List<GetBusinessActivitieDto>>> GetAll();
		Task<ApiResponse<GetBusinessActivitieDto>> GetById(int id);
		Task<ApiResponse<GetBusinessActivitieDto>> AddBusinessActivitie(AddBusinessActivitieDto businessActivitieDto);
		Task<ApiResponse<GetBusinessActivitieDto>> UpdateBusinessActivitie(UpdateBusinessActivitieDto updateBusinessActivitieDto);
		Task<ApiResponse<List<GetBusinessActivitieDto>>> DeleteById(int id);
	}
}
