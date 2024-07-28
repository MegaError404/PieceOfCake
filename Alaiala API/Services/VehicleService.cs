using Alaiala_API.Data;
using Alaiala_API.Interfaces;
using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.Vehicle;
using Alaiala_API.ServicesIntrfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Alaiala_API.Services
{
    public class VehicleService : IRegisterService, IVehicleService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public VehicleService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public static void RegisterMe(IServiceCollection services)
        {
            services.AddScoped<IVehicleService, VehicleService>();
        }
        public async Task<ApiResponse<List<GetVehicleDto>>> GetAllVehicle()
        {
            var response = new ApiResponse<List<GetVehicleDto>>();
            try
            {
                var vehicles = await _dataContext.Vehicles.ToListAsync();
                response.Data = _mapper.Map<List<GetVehicleDto>>(vehicles);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
        
        public async Task<ApiResponse<GetVehicleDto>> GetVehicleById(int id)
        {
            var response = new ApiResponse<GetVehicleDto>();
            try
            {
                var vehicle = await _dataContext.Vehicles.FirstOrDefaultAsync(go => go.ID == id);

                if (vehicle is null)
                {
                    response.Success = false;
                    response.Message = "Vehicle Not Found .";
                }
                else
                    response.Data = _mapper.Map<GetVehicleDto>(vehicle);

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ApiResponse<GetVehicleDto>> AddVehicle(AddVehicleDto addVehicleDto)
        {
            var response = new ApiResponse<GetVehicleDto>();
            try
            {
                var vehicle = new Vehicles
                {
                    GUID=Guid.NewGuid(),
                    Name=addVehicleDto.Name
                };
                await _dataContext.Vehicles.AddAsync(vehicle);
                await _dataContext.SaveChangesAsync();

                response.Data = _mapper.Map<GetVehicleDto>(vehicle);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
        public async Task<ApiResponse<GetVehicleDto>> UpdateVehicle(UpdateVehicleDto updateVehicleDto)
        {
            var response = new ApiResponse<GetVehicleDto>();
            try
            {
                var vehicle = await _dataContext.Vehicles.FirstOrDefaultAsync(ve => ve.ID == updateVehicleDto.ID);

                if (vehicle is null)
                {
                    response.Success = false;
                    response.Message = "Not found";
                }
                else
                {
                    vehicle.Name = updateVehicleDto.Name;
                    await _dataContext.SaveChangesAsync();

                    response.Data = _mapper.Map<GetVehicleDto>(vehicle);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ApiResponse<List<GetVehicleDto>>> DeleteById(int id)
        {
            var response = new ApiResponse<List<GetVehicleDto>>();
            try
            {
                var vehicle = await _dataContext.Vehicles.FirstOrDefaultAsync(ve => ve.ID == id);

                if (vehicle == null)
                {
                    response.Success = false;
                    response.Message = "Vehicle Not Found .";
                }
                else
                {
                    _dataContext.Vehicles.Remove(vehicle);
                    await _dataContext.SaveChangesAsync();
                    response.Data = await _dataContext.Vehicles.Select(go => _mapper.Map<GetVehicleDto>(go))
                                                                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
