using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PieceOfCakeAPI.Data;
using PieceOfCakeAPI.Helper;
using PieceOfCakeAPI.Interfaces;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace PieceOfCakeAPI.Services
{
	public static class AppServices
	{
		/// <summary>
		/// Add all services used in applecation
		/// </summary>
		public static void AddServices(this IServiceCollection Services, WebApplicationBuilder builder)
		{
			Services.AddDbContext<DataContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection")));
			Services.AddAutoMapper(typeof(Program).Assembly);
			Services.AddControllers();
			Services.AddEndpointsApiExplorer();
			Services.AddSwaggerGen(configuration =>
			{
				configuration.AddSecurityDefinition(AuthenticationHelper.AppSchemas.Captain, new OpenApiSecurityScheme
				{
					Description = "Standard Authorization header using the Captain scheme, e.g. \"Captain {token}\"",
					In = ParameterLocation.Header,
					Name = "CaptainAuthorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = AuthenticationHelper.AppSchemas.Captain
				});

				configuration.AddSecurityDefinition(AuthenticationHelper.AppSchemas.Merchant, new OpenApiSecurityScheme
				{
					Description = "Standard Authorization header using the Merchant scheme, e.g. \"Merchant {token}\"",
					In = ParameterLocation.Header,
					Name = "MerchantAuthorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = AuthenticationHelper.AppSchemas.Merchant
				});

				configuration.OperationFilter<SecurityRequirementsOperationFilter>();
			});
			Services.AddControllersServices();

			Services.AddAuthentication()
			.AddJwtBearer(AuthenticationHelper.AppSchemas.Captain, options =>
			{
				string? tokenValue = builder.Configuration.GetSection("AppSettings:Token").Value;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenValue is null ? "" : tokenValue)),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			})
			.AddJwtBearer(AuthenticationHelper.AppSchemas.Merchant, options =>
			{
				string? tokenValue = builder.Configuration.GetSection("AppSettings:Token").Value;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenValue is null ? "" : tokenValue)),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			//Services.AddAuthorization(options =>
			//{
			//	//options.DefaultPolicy = new AuthorizationPolicyBuilder()
			//	//	.RequireAuthenticatedUser()
			//	//	.AddAuthenticationSchemes(AuthenticationHelper.AppSchemas.Captain, AuthenticationHelper.AppSchemas.Merchant)
			//	//	.Build();
			//	var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme, "AzureAD");
			//	defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
			//	options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();

			//	options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme, "AzureAD")
			//	.RequireAuthenticatedUser()
			//	.Build();
			//});
		}

		/// <summary>
		/// This methode register all classes implement the IRegisterService intrface
		/// </summary>
		public static void AddControllersServices(this IServiceCollection services)
		{
			var controllersServiceTypesList = typeof(IRegisterService)
				.Assembly
				.GetTypes()
				.Where(t => t.IsClass && !t.IsAbstract && typeof(IRegisterService).IsAssignableFrom(t))
				.ToArray();

			foreach (var controllerServiceType in controllersServiceTypesList)
			{
				controllerServiceType.GetMethod("RegisterMe")?.Invoke(null, new object[] { services });
			}
		}

		public static void HandleGlobalExceptions(this WebApplication app)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					context.Response.StatusCode = 500;
					context.Response.ContentType = "application/json";

					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature is not null)
					{
						await context.Response.WriteAsJsonAsync(new
						{
							context.Response.StatusCode,
							Message = "Unhandled Internal Server Error!"
						});
					}
				});
			});
		}

	}
}
