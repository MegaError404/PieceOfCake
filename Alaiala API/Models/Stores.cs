using PieceOfCakeAPI.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.Models
{
	public class Stores
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[
		  Required,
		  MaxLength(100, ErrorMessage = "Max Length in Store Name 100 Character"),
		  MinLength(4, ErrorMessage = "Min Length in Store Name 4 Character")
		]
		public string Name { get; set; } = string.Empty;

		[Required]
		public Merchants.Merchants Merchant { get; set; }

		public byte[] Logo { get; set; } = new byte[0];

		[Required(ErrorMessage = "PrimaryNumberPhone Is Required"), Phone]
		public string PrimaryNumberPhone { get; set; } = string.Empty;

		[Phone]
		public string SecondaryNumberPhone { get; set; } = string.Empty;

		[Required(ErrorMessage = "Address Is Required")]
		public string Address { get; set; } = string.Empty;

		[Required(ErrorMessage = "OnmapLocation Is Required")]
		public string OnmapLocation { get; set; } = string.Empty;

		[Required]
		public BusinessActivities BusinessActivity { get; set; }

		[Required]
		public Governorates Governorate { get; set; }
		public ActivetyStatus ActivetyStatus { get; set; } = ActivetyStatus.None;
	}
}