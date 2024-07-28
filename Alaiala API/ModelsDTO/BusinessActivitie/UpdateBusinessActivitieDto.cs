using System.ComponentModel.DataAnnotations;

namespace PieceOfCakeAPI.ModelsDTO.BusinessActivitie
{
	public class UpdateBusinessActivitieDto
	{
		public int ID { get; set; } = 0;
		public string Name { get; set; } = string.Empty;
	}
}
