using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.Vehicle;

namespace Alaiala_API.ServicesIntrfaces
{
    public interface IVehicleService
    {
      Task<ApiResponse<List<GetVehicleDto>>> GetAllVehicle();
      Task<ApiResponse<GetVehicleDto>> GetVehicleById(int id);
      Task<ApiResponse<GetVehicleDto>> AddVehicle(AddVehicleDto addVehicleDto);
      Task<ApiResponse<GetVehicleDto>> UpdateVehicle(UpdateVehicleDto updateVehicleDto);
      Task<ApiResponse<List<GetVehicleDto>>> DeleteById(int id);
    }
}
