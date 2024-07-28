using PieceOfCakeAPI.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PieceOfCakeAPI.Models.Captains
{
	public class Captains
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required(ErrorMessage = "PersonalPhoto Is Required")]
		public byte[] PersonalPhoto { get; set; } = new byte[0];

		[Required]
		public Governorates Governorate { get; set; }

		[Required(ErrorMessage = "Captian Name Is Required"),
		  MaxLength(100, ErrorMessage = "Max Length in Captain Name 100 Character"),
		  MinLength(4, ErrorMessage = "Min Length in Captain Name 4 Character")
		]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Captian Nick Name Is Required"),
		  MaxLength(100, ErrorMessage = "Max Length in Captain Nick Name 100 Character"),
		  MinLength(4, ErrorMessage = "Min Length in Captain Nick Name 4 Character")
		]
		public string Nickname { get; set; } = string.Empty;

		[Required(ErrorMessage = "Primary PhoneNumber Is Required"), Phone]
		public string PrimaryPhoneNumber { get; set; } = string.Empty;

		[Phone]
		public string SecondaryPhoneNumber { get; set; } = string.Empty;

		[Required(ErrorMessage = "Address Is Required")]
		public string Address { get; set; } = string.Empty;

		[Required(ErrorMessage = "Marital Status Is Required")]
		public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.None;

		[Required(ErrorMessage = "PersonalIdentificationID Is Required")]
		public string PersonalIdentificationID { get; set; } = string.Empty;

		[Required(ErrorMessage = "FirstPersonalIdentificationPhoto Is Required")]
		public byte[] FirstPersonalIdentificationPhoto { get; set; } = new byte[0];

		[Required(ErrorMessage = "SecondPersonalIdentificationPhoto Is Required")]
		public byte[] SecondPersonalIdentificationPhoto { get; set; } = new byte[0];

		[Required]
		public Vehicles Vehicle { get; set; }

		[Required(ErrorMessage = "Relative Name Is Required")]
		public string RelativeName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Relative PhoneNumber Is Required"), Phone]
		public string RelativePhoneNumber { get; set; } = string.Empty;

		[Required(ErrorMessage = "RelationShip Is Required")]
		public RelationShip RelationShip { get; set; } = RelationShip.None;

		[Required(ErrorMessage = "Activety Status Is Required")]
		public ActivetyStatus ActivetyStatus { get; set; } = ActivetyStatus.None;

		[Required]
		public byte[] PasswordHash { get; set; } = Guid.Empty.ToByteArray();

		[Required]
		public byte[] PasswordSalt { get; set; } = Guid.Empty.ToByteArray();

		[Required(ErrorMessage = "Work Start Date Is Required")]
		public DateTime WorkStartDate { get; set; } = DateTime.MinValue;

		[Required(ErrorMessage = "Work End Date Is Required")]
		public DateTime WorkEndDate { get; set; } = DateTime.MaxValue;

		[Required(ErrorMessage = "Join Date Is Required")]
		public DateTime JoinDate { get; set; } = DateTime.MinValue;

		[Required]
		public Guid InvitingCode { get; set; } = new Guid();

		public List<Claim> GetClaims()
		{
			return new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, GUID.ToString()),
				new Claim(ClaimTypes.MobilePhone, PrimaryPhoneNumber)
			};
		}
	}
}
