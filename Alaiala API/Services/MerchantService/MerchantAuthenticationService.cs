using Alaiala_API.Data;
using Alaiala_API.Enumerations;
using Alaiala_API.Helper;
using Alaiala_API.Interfaces;
using Alaiala_API.Models;
using Alaiala_API.Models.Merchants;
using Alaiala_API.ModelsDTO.Merchant;
using Alaiala_API.ServicesIntrfaces.Merchant;
using Microsoft.EntityFrameworkCore;

namespace Alaiala_API.Services.Merchant
{
	public class MerchantAuthenticationService : IRegisterService, IMerchantAuthenticationService
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<MerchantService> _logger;
        private readonly IConfiguration _configuration;

        public MerchantAuthenticationService(DataContext dataContext, ILogger<MerchantService> logger, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _logger = logger;
            _configuration = configuration;
        }

        public static void RegisterMe(IServiceCollection services)
        {
            services.AddScoped<IMerchantAuthenticationService, MerchantAuthenticationService>();
        }

        public async Task<ApiResponse<string>> Register(MerchantRegisterRequest request)
        {
            var respone = new ApiResponse<string>();
            try
            {
                if (!await MerchantExsist(request.MerchantName))
                {
                    respone.Success = false;
                    respone.Message = "Merchant Already Exsist";
                    return respone;
                }

                var governorate = GetGovernorate(request.GovernorateID);
                if (governorate is null)
                {
                    respone.Success = false;
                    respone.Message = "Governorate Not Exsist";
                    return respone;
                }

                var businessActivity = GetBusinessActivitie(request.BusinessActivityID);
                if (businessActivity is null)
                {
                    respone.Success = false;
                    respone.Message = "BusinessActivity Not Exsist";
                    return respone;
                }

                AuthenticationHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

                var merchant = new Merchants
                {
                    GUID = Guid.NewGuid(),
                    Name = request.MerchantName,
                    PrimaryPhoneNumber = request.PrimaryPhoneNumber,
                    SecondaryPhoneNumber = request.SecondaryPhoneNumber,
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    InvitingCode = Guid.NewGuid(),
                    ActivetyStatus = ActivetyStatus.Pending
                };

                var store = new Stores
                {
                    GUID = Guid.NewGuid(),
                    Name = request.SotreName,
                    Merchant = merchant,
                    Logo = System.Text.Encoding.UTF8.GetBytes(request.Logo),
                    PrimaryNumberPhone = request.PrimaryNumberPhone,
                    SecondaryNumberPhone = request.SecondaryNumberPhone,
                    Address = request.Address,
                    OnmapLocation = request.OnmapLocation,
                    BusinessActivity = businessActivity,
                    Governorate = governorate,
                    ActivetyStatus = ActivetyStatus.Pending
                };

                await _dataContext.Merchants.AddAsync(merchant);
                await _dataContext.Stores.AddAsync(store);
                await _dataContext.SaveChangesAsync();

                respone.Data = "Register Merchant Is Success";
            }
            catch (Exception ex)
            {
                respone.Success = false;
                respone.Message = ex.Message;
            }
            return respone;
        }

        public async Task<ApiResponse<string>> LogIn(MerchantLogInRequest request)
        {
            var response = new ApiResponse<string>();
            try
            {
                var merchant = await _dataContext.Merchants.FirstOrDefaultAsync(me => me.PrimaryPhoneNumber == request.PrimaryPhoneNumber);
                if (merchant is null || !AuthenticationHelper.VerifyPasswordHash(request.Password, merchant.PasswordHash, merchant.PasswordSalt))
                {
                    response.Message = MerchantLogInResponse.ResponseState.InvalidPhoneNumberOrPassword.ToString();
                    response.Success = false;
                    return response;
                }
                else
                    response.Data = AuthenticationHelper.CreateToken(request.GetClaims(), _configuration);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        private Governorates GetGovernorate(int governorateId)
        {
            return _dataContext.Governorates.FirstOrDefault(go => go.Id == governorateId);
        }
        private BusinessActivities GetBusinessActivitie(int businessActivitieId)
        {
            return _dataContext.BusinessActivities.FirstOrDefault(go => go.Id == businessActivitieId);
        }
        public async Task<bool> MerchantExsist(string merchantName)
        {
            var merchant = await _dataContext.Merchants.FirstOrDefaultAsync(u => u.Name == merchantName);

            if (merchant is null)
                return true;

            return false;
        }
    }
}
