using AutoMapper;
using PieceOfCakeAPI.Models;
using PieceOfCakeAPI.ModelsDTO.BusinessActivitie;
using PieceOfCakeAPI.ModelsDTO.Governorate;
using PieceOfCakeAPI.ModelsDTO.Subscription;
using PieceOfCakeAPI.ModelsDTO.Vehicle;

namespace PieceOfCakeAPI
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Governorates, GovernoratesGetResponse>();
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
