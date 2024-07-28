using PieceOfCakeAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.Models.Merchants
{
	public class MerchantsSubscriptions
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required]
		public DateTime StartDate { get; set; } = DateTime.MinValue;

		[Required]
		public Merchants Merchant { get; set; }

		[Required]
		public Subscriptions Subscriptions { get; set; }
	}
}
