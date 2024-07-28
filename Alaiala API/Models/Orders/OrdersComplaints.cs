using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.Models.Orders
{
	// TODO : متى يمكن تقديم الشكاوي وعلى أي أساس
	public class OrdersComplaints
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required]
		public Guid OrderGUID { get; set; } = Guid.Empty;

		[Required]
		public string ComplaintText { get; set; } = string.Empty;

		[Required]
		public Merchants.Merchants Merchant { get; set; }

	}
}
