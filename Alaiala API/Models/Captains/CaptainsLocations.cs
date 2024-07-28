using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.Models.Captains
{
	public class CaptainsLocations
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid Guid { get; set; } = Guid.Empty;

		[Required]
		public string OnmapLocation { get; set; } = string.Empty;

		[Required]
		public Captains Captain { get; set; }
	}
}
