namespace PieceOfCakeAPI.ModelsDTO.Subscription
{
	public class GetSubscriptionDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Cost { get; set; } = decimal.Zero;
		public int Duration { get; set; } = 0;
	}
}
