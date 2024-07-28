using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PieceOfCakeAPI.Models.Merchants
{
	public class MerchantsNotes
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required(ErrorMessage = "Note Is Required")]
		public string Note { get; set; } = string.Empty;

		[Required]
		public Merchants Merchant { get; set; }
	}
}
