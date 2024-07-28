using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace PieceOfCakeAPI.Helper
{
	public sealed class AuthenticationHelper
	{
		public static string CreateToken(List<Claim> claims, IConfiguration _configuration)
		{
			SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
			.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

			SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
			SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddSeconds(60),
				SigningCredentials = credentials
			};

			JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);

			return jwtSecurityTokenHandler.WriteToken(securityToken);
		}

		public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512(passwordSalt))
			{
				var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

				return computeHash.SequenceEqual(passwordHash);
			}
		}

		public class AppSchemas
		{
			public const string None = "None";
			public const string Admian = "Admian";
			public const string Captain = "Captain";
			public const string Merchant = "Merchant";
		}
	}
}