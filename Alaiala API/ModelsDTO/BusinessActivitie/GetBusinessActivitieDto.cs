using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.ModelsDTO.BusinessActivitie
{
	public class GetBusinessActivitieDto
	{
		public int ID { get; set; } = 0;
		public string Name { get; set; } = string.Empty;
	}
}
