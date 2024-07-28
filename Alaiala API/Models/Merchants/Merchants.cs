using PieceOfCakeAPI.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.Models.Merchants
{
	public class Merchants
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required(ErrorMessage = "Merchants Name Is Required"),
		  MaxLength(100, ErrorMessage = "Max Length in Merchants Name 100 Character"),
		  MinLength(4, ErrorMessage = "Min Length in Merchants Name 4 Character")
		]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Primary PhoneNumber Is Required"), Phone]
		public string PrimaryPhoneNumber { get; set; } = string.Empty;
		[Phone]
		public string SecondaryPhoneNumber { get; set; } = string.Empty;

		[Required(ErrorMessage = "ActivetyStatus Is Required")]
		public ActivetyStatus ActivetyStatus { get; set; } = ActivetyStatus.None;

		[Required]
		public byte[] PasswordHash { get; set; } = Guid.Empty.ToByteArray();

		[Required]
		public byte[] PasswordSalt { get; set; } = Guid.Empty.ToByteArray();

		[Required]
		public Guid InvitingCode { get; set; } = new Guid();
	}
}
