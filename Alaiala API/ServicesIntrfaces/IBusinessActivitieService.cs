using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.BusinessActivitie;

namespace Alaiala_API.ServicesIntrfaces
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
