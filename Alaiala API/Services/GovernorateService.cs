using Alaiala_API.Data;
using Alaiala_API.Interfaces;
using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.Governorate;
using Alaiala_API.ServicesIntrfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Alaiala_API.Services
{
    public class GovernorateService : IRegisterService, IGovernorateService
	{
        private readonly ILogger<GovernorateService> _Logger;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public GovernorateService(ILogger<GovernorateService> logger,IMapper mapper,DataContext dataContext)
        {
            _Logger = logger;
            _mapper = mapper;
            _dataContext = dataContext;
        }

		public static void RegisterMe(IServiceCollection services)
		{
			services.AddScoped<IGovernorateService, GovernorateService>();
		}
		
        public async Task<ApiResponse<List<GovernoratesGetResponse>>> GetAllGovernorates()
		{
            var response = new ApiResponse<List<GovernoratesGetResponse>>();
            try
            {
                var governorates = await _dataContext.Governorates.ToListAsync();

                response.Data = _mapper.Map<List<GovernoratesGetResponse>>(governorates);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

		public async Task<ApiResponse<GovernoratesGetResponse>> GetGovernorateById(int id)
		{
            var response = new ApiResponse<GovernoratesGetResponse>();
            try
            {
                var governorate = await _dataContext.Governorates.FirstOrDefaultAsync(go => go.Id == id);

                if (governorate is null)
                {
                    response.Success = false;
                    response.Message = "Not found";
                }
                else 
                response.Data = _mapper.Map<GovernoratesGetResponse>(governorate);

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

		public async Task<ApiResponse<GovernoratesAddResponse>> AddGovernorate(GovernoratesAddRequest requestGovernorate)
		{
			var response = new ApiResponse<GovernoratesAddResponse>();
			try 
			{
				var governorates = new Governorates
				{
					GUID = Guid.NewGuid(),
					Name = requestGovernorate.Name, 
					OrderDeliveryCost = requestGovernorate.OrderDeliveryCost, 
				};
				await _dataContext.Governorates.AddAsync(governorates);
				await _dataContext.SaveChangesAsync();

				response.Data = _mapper.Map<GovernoratesAddResponse>(governorates);

            }
			catch(Exception ex)
			{
				response.Message = ex.Message;
				response.Success = false;
			}
			return response;
        }
        
        public async Task<ApiResponse<List<GovernoratesGetResponse>>> DeleteById(int id)
        {
            var response = new ApiResponse<List<GovernoratesGetResponse>>();
            try
            {
                var governorate = await _dataContext.Governorates.FindAsync(id);

                if (governorate == null)
                {
                    response.Success = false;
                    response.Message = "Not found";
                }
                else
                {
                    _dataContext.Governorates.Remove(governorate);
                    await _dataContext.SaveChangesAsync();
                    response.Data =  await _dataContext.Governorates.Select(go => _mapper.Map<GovernoratesGetResponse>(go))
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

        public async Task<ApiResponse<GovernoratesGetResponse>> UpdateGovernorate(UpdateGovernorate updateGovernorate)
        {
            var response = new ApiResponse<GovernoratesGetResponse>();
            try
            {
                var governorate = await _dataContext.Governorates.FirstOrDefaultAsync(go => go.Id == updateGovernorate.ID);

                if (governorate is null)
                {
                    response.Success = false;
                    response.Message = "Not found";
                }
                else
                {
                    governorate.Name = updateGovernorate.Name;
                    governorate.OrderDeliveryCost = updateGovernorate.OrderDeliveryCost;

                    await _dataContext.SaveChangesAsync();

                    response.Data = _mapper.Map<GovernoratesGetResponse>(governorate);
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
