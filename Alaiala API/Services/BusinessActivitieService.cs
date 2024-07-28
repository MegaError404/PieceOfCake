using Alaiala_API.Data;
using Alaiala_API.Interfaces;
using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.BusinessActivitie;
using Alaiala_API.ServicesIntrfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Alaiala_API.Services
{
    public class BusinessActivitieService : IBusinessActivitieService, IRegisterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public BusinessActivitieService(IMapper mapper,DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public static void RegisterMe(IServiceCollection services)
        {
            services.AddScoped<IBusinessActivitieService,BusinessActivitieService>();
        }
      
        public async Task<ApiResponse<List<GetBusinessActivitieDto>>> GetAll()
        {
            var response = new ApiResponse<List<GetBusinessActivitieDto>>();
            try
            {
                response.Data = await _dataContext.BusinessActivities.Select(bu => _mapper.Map<GetBusinessActivitieDto>(bu))
                                                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<GetBusinessActivitieDto>> AddBusinessActivitie(AddBusinessActivitieDto businessActivitieDto)
        {
            var response = new ApiResponse<GetBusinessActivitieDto>();
            try 
            {
                var businessActivity = new BusinessActivities
                {
                    GUID = Guid.NewGuid(),
                    Name=businessActivitieDto.Name
                };
                await _dataContext.BusinessActivities.AddAsync(businessActivity);
                await _dataContext.SaveChangesAsync();
                response.Data = _mapper.Map<GetBusinessActivitieDto>(businessActivity);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        
        public async Task<ApiResponse<GetBusinessActivitieDto>> GetById(int id)
        {
            var response = new ApiResponse<GetBusinessActivitieDto>();
            try
            {
                var businessActivity = await _dataContext.BusinessActivities.FirstOrDefaultAsync(go => go.Id == id);

                if (businessActivity is null)
                {
                    response.Success = false;
                    response.Message = "Not found";
                }
                else
                    response.Data = _mapper.Map<GetBusinessActivitieDto>(businessActivity);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ApiResponse<GetBusinessActivitieDto>> UpdateBusinessActivitie(UpdateBusinessActivitieDto updateBusinessActivitieDto)
        {
            var response = new ApiResponse<GetBusinessActivitieDto>();
            try
            {
                var businessActivity = await _dataContext.BusinessActivities.FirstOrDefaultAsync(go => go.Id == updateBusinessActivitieDto.ID);

                if (businessActivity is null)
                {
                    response.Success = false;
                    response.Message = "Not found";
                }
                else
                {
                    businessActivity.Name = updateBusinessActivitieDto.Name;

                    await _dataContext.SaveChangesAsync();

                    response.Data = _mapper.Map<GetBusinessActivitieDto>(businessActivity);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ApiResponse<List<GetBusinessActivitieDto>>> DeleteById(int id)
        {
            var response = new ApiResponse<List<GetBusinessActivitieDto>>();
            try
            {
                var businessActivity = await _dataContext.BusinessActivities.FirstOrDefaultAsync(c => c.Id == id);

                if (businessActivity == null)
                {
                    response.Success = false;
                    response.Message = "Not found";
                }
                else
                {
                    _dataContext.BusinessActivities.Remove(businessActivity);
                    await _dataContext.SaveChangesAsync();
                    response.Data = await _dataContext.BusinessActivities.Select(go => _mapper.Map<GetBusinessActivitieDto>(go))
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
