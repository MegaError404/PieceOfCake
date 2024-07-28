using Alaiala_API.Models;
using Alaiala_API.ModelsDTO.BusinessActivitie;
using Alaiala_API.ModelsDTO.Governorate;
using Alaiala_API.ModelsDTO.Subscription;
using Alaiala_API.ModelsDTO.Vehicle;
using AutoMapper;

namespace Alaiala_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Governorates,GovernoratesGetResponse>();
            CreateMap<Governorates, GovernoratesAddResponse>();
            CreateMap<Governorates, UpdateGovernorate>();
            CreateMap<BusinessActivities, GetBusinessActivitieDto>();
            CreateMap<Vehicles, GetVehicleDto>();
            CreateMap<Vehicles, AddVehicleDto>();
            CreateMap<Subscriptions, AddSubscriptionDto>();
            CreateMap<Subscriptions, GetSubscriptionDto>();
        }
    }
}
