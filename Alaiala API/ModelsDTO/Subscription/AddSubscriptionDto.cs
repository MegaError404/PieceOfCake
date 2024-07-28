namespace Alaiala_API.ModelsDTO.Subscription
{
    public class AddSubscriptionDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; } = decimal.Zero;
        public int Duration { get; set; } = 0;
    }
}
