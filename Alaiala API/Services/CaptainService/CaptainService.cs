using AutoMapper;
using PieceOfCakeAPI.Interfaces;
using PieceOfCakeAPI.ServicesIntrfaces.Captain;

namespace PieceOfCakeAPI.Services.CaptainService
{
	public class CaptainService : IRegisterService, ICaptainService
	{
		ILogger<CaptainService> _Logger;
		IMapper _Mapper;

		public CaptainService(ILogger<CaptainService> logger, IMapper mapper)
		{
			_Logger = logger;
			_Mapper = mapper;
		}

		public static void RegisterMe(IServiceCollection services)
		{
			services.AddSingleton<ICaptainService, CaptainService>();
		}
	}
}
