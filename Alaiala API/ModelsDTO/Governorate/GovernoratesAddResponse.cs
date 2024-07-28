using PieceOfCakeAPI.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.ModelsDTO.Governorate
{
	public class GovernoratesAddResponse : IDtoResponse
	{
		public int ID { get; set; } = 0;
		public string Name { get; set; } = string.Empty;
		public decimal OrderDeliveryCost { get; set; } = decimal.Zero;
	}
}
