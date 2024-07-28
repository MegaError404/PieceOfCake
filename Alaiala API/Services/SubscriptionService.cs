using Alaiala_API.Data;
using Alaiala_API.Interfaces;
using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.Subscription;
using Alaiala_API.ServicesIntrfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Alaiala_API.Services
{
    public class SubscriptionService : IRegisterService, ISubscriptionService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        
        public SubscriptionService(IMapper mapper,DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public static void RegisterMe(IServiceCollection services)
        {
            services.AddScoped<ISubscriptionService, SubscriptionService>();
        }
        public async Task<ApiResponse<List<GetSubscriptionDto>>> GetAllSubscription()
        {
            var response = new ApiResponse<List<GetSubscriptionDto>>();
            try
            {
                var subscriptions = await _dataContext.Subscriptions.ToListAsync();
                response.Data = _mapper.Map<List<GetSubscriptionDto>>(subscriptions);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    
        public async Task<ApiResponse<GetSubscriptionDto>> GetSubscriptionById(int id)
        {
            var response = new ApiResponse<GetSubscriptionDto>();
            try
            {
                var subscription = await _dataContext.Subscriptions.FirstOrDefaultAsync(go => go.Id == id);

                if (subscription is null)
                {
                    response.Success = false;
                    response.Message = "subscription Not Found .";
                }
                else
                    response.Data = _mapper.Map<GetSubscriptionDto>(subscription);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ApiResponse<GetSubscriptionDto>> AddSubscription(AddSubscriptionDto addSubscriptionDto)
        {
            var response = new ApiResponse<GetSubscriptionDto>();
            try
            {
                var subscription = new Subscriptions
                {
                    GUID = Guid.NewGuid(),
                    Name= addSubscriptionDto.Name,
                    Cost= addSubscriptionDto.Cost,
                    Duration= addSubscriptionDto.Duration
                };
                await _dataContext.Subscriptions.AddAsync(subscription);
                await _dataContext.SaveChangesAsync();

                response.Data = _mapper.Map<GetSubscriptionDto>(subscription);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ApiResponse<GetSubscriptionDto>> UpdateSubscription(UpdateSubscriptionDto updateSubscriptionDto)
        {
            var response = new ApiResponse<GetSubscriptionDto>();
            try
            {
                var subscription = await _dataContext.Subscriptions.FirstOrDefaultAsync(ve => ve.Id == updateSubscriptionDto.Id);

                if (subscription is null)
                {
                    response.Success = false;
                    response.Message = "Subscription Not Found .";
                }
                else
                {
                    subscription.Name     =updateSubscriptionDto.Name;
                    subscription.Cost     = updateSubscriptionDto.Cost;
                    subscription.Duration = updateSubscriptionDto.Duration; 
                   await _dataContext.SaveChangesAsync();

                    response.Data = _mapper.Map<GetSubscriptionDto>(subscription);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ApiResponse<List<GetSubscriptionDto>>> DeleteById(int id)
        {
            var response = new ApiResponse<List<GetSubscriptionDto>>();
            try
            {
                var subscription = await _dataContext.Subscriptions.FirstOrDefaultAsync(ve => ve.Id == id);

                if (subscription == null)
                {
                    response.Success = false;
                    response.Message = "Subscription Not Found .";
                }
                else
                {
                    _dataContext.Subscriptions.Remove(subscription);
                    await _dataContext.SaveChangesAsync();
                    response.Data = await _dataContext.Subscriptions.Select(go => _mapper.Map<GetSubscriptionDto>(go))
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
