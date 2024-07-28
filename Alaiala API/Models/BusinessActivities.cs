using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.Models
{
	public class BusinessActivities
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required]
		public string Name { get; set; } = string.Empty;
	}
}
