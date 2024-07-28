using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.Models
{
	// TODO : فهم الية عمل تصفير الطلبات والفئات
	public class Categories
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		public int OrdersCount { get; set; } = 0;

		[Required]
		public int Duration { get; set; } = 0;
	}
}
