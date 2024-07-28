using Alaiala_API.Interfaces;

namespace Alaiala_API.ModelsDTO.Governorate
{
    public class GovernoratesGetResponse : IDtoResponse
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public decimal OrderDeliveryCost { get; set; } = decimal.Zero;
    }
}
