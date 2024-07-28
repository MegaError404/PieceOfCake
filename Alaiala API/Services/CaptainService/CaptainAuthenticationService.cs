using Alaiala_API.Data;
using Alaiala_API.Enumerations;
using Alaiala_API.Helper;
using Alaiala_API.Interfaces;
using Alaiala_API.Models;
using Alaiala_API.Models.Merchants;
using Alaiala_API.ModelsDTO.Captain;
using Alaiala_API.ServicesIntrfaces.Captain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Alaiala_API.Services.Captain
{
	public class CaptainAuthenticationService : IRegisterService, ICaptainAuthenticationService
    {
		private readonly DataContext _dataContext;
		private readonly ILogger<CaptainService> _logger;
        private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;

		public CaptainAuthenticationService(DataContext dataContext, ILogger<CaptainService> logger, IMapper mapper, IConfiguration configuration)
        {
			_dataContext = dataContext;
			_logger = logger;
            _mapper = mapper;
			_configuration = configuration;
        }

        public static void RegisterMe(IServiceCollection services)
        {
            services.AddScoped<ICaptainAuthenticationService, CaptainAuthenticationService>();
        }

        public async Task<ApiResponse<CaptainLogInResponse>> LogIn(CaptainLogInRequest request)
        {
			ApiResponse<CaptainLogInResponse> responese = new();

			try
			{
				var captain = await _dataContext.Captains.FirstOrDefaultAsync(me => me.PrimaryPhoneNumber == request.PrimaryPhoneNumber);
				if (captain is null || !AuthenticationHelper.VerifyPasswordHash(request.Password, captain.PasswordHash, captain.PasswordSalt))
				{
					responese.Message = CaptainLogInResponse.ResponseState.InvalidPhoneNumberOrPassword.ToString();
					responese.Success = false;
					return responese;
				}

				var data = new CaptainLogInResponse()
				{
					Token = AuthenticationHelper.CreateToken(captain.GetClaims(), _configuration)
				};

				responese.Data = data;
			}
			catch (Exception)
			{
				throw;
			}

			return responese;
		}

        public async Task<ApiResponse<CaptainRegisterResponse>> Register(CaptainRegisterRequest request)
        {
			var responese = new ApiResponse<CaptainRegisterResponse>();

			try
			{
				if (await _dataContext.Captains.FirstOrDefaultAsync(u => u.Name == request.Name) is null)
				{
					responese.Success = false;
					responese.Message = CaptainRegisterResponse.ResponseState.CaptainAlreadyExsist.ToString();
					return responese;
				}

				if (await _dataContext.Governorates.FirstOrDefaultAsync(go => go.Id == request.GovernorateID) is null)
				{
					responese.Success = false;
					responese.Message = CaptainRegisterResponse.ResponseState.GovernorateNotExsist.ToString();
					return responese;
				}

				AuthenticationHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

				var merchant = new Merchants
				{
					GUID = Guid.NewGuid(),
					Name = request.Name,
					PrimaryPhoneNumber = request.PrimaryPhoneNumber,
					SecondaryPhoneNumber = request.SecondaryPhoneNumber,
					PasswordSalt = passwordSalt,
					PasswordHash = passwordHash,
					InvitingCode = Guid.NewGuid(),
					ActivetyStatus = ActivetyStatus.Pending
				};

				await _dataContext.Merchants.AddAsync(merchant);
				await _dataContext.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}

			return responese;
		}
    }
}
