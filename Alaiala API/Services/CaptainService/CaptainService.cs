using Alaiala_API.Interfaces;
using Alaiala_API.ServicesIntrfaces.Captain;
using AutoMapper;

namespace Alaiala_API.Services.Captain
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
