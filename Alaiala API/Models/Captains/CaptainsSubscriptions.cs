using PieceOfCakeAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.Models.Captains
{
	public class CaptainsSubscriptions
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required]
		public DateTime StartDate { get; set; } = DateTime.MinValue;

		[Required]
		public Captains Captain { get; set; }

		[Required]
		public Subscriptions Subscription { get; set; }
	}
}
