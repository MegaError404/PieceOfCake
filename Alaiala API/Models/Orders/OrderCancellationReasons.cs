using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.Models.Orders
{
	public class OrderCancellationReasons
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required]
		public string Reason { get; set; } = string.Empty;

	}
}
