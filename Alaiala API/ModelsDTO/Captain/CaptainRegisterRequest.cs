using PieceOfCakeAPI.Enumerations;
using PieceOfCakeAPI.Interfaces;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace PieceOfCakeAPI.ModelsDTO.Captain
{
	public class CaptainRegisterRequest : IDtoRequest
	{
		public string PersonalPhoto { get; set; } = string.Empty;
		public int GovernorateID { get; set; } = 0;
		public string Name { get; set; } = string.Empty;
		public string Nickname { get; set; } = string.Empty;
		public string PrimaryPhoneNumber { get; set; } = string.Empty;
		public string SecondaryPhoneNumber { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.None;
		public string PersonalIdentificationID { get; set; } = "0";
		public string FirstPersonalIdentificationPhoto { get; set; } = string.Empty;
		public string SecondPersonalIdentificationPhoto { get; set; } = string.Empty;
		public int VehicleID { get; set; } = 0;
		public string RelativeName { get; set; } = string.Empty;
		public string RelativePhoneNumber { get; set; } = string.Empty;
		public RelationShip RelationShip { get; set; } = RelationShip.None;
		public string Password { get; set; } = string.Empty;
	}

}
