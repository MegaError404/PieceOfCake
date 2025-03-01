﻿using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.Models.Merchants
{
	public class MerchantNotifications
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required(ErrorMessage = "Title Is Required")]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = "Text Is Required")]
		public string Text { get; set; } = string.Empty;
	}
}