using Alaiala_API.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Alaiala_API.ModelsDTO.Governorate
{
    public class GovernoratesAddResponse : IDtoResponse
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public decimal OrderDeliveryCost { get; set; } = decimal.Zero;
    }
}
