namespace PieceOfCakeAPI.ModelsDTO.Governorate
{
	public class UpdateGovernorate
	{
		public int ID { get; set; } = 0;
		public string Name { get; set; } = string.Empty;
		public decimal OrderDeliveryCost { get; set; } = decimal.Zero;
	}
}
