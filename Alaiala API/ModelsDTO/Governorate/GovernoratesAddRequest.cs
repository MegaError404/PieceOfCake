using PieceOfCakeAPI.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.ModelsDTO.Governorate
{
	public class GovernoratesAddRequest : IDtoRequest
	{
		public string Name { get; set; } = string.Empty;
		public decimal OrderDeliveryCost { get; set; } = decimal.Zero;
	}
}
