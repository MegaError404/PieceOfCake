using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.Models.Captains
{
	public class CaptainsNotifications
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required(ErrorMessage = "Title Is Required")]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = "Text Is Required")]
		public string Text { get; set; } = string.Empty;

		[Required]
		public Captains Captain { get; set; }
	}
}
