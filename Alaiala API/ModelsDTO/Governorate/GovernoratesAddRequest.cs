using Alaiala_API.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Alaiala_API.ModelsDTO.Governorate
{
    public class GovernoratesAddRequest : IDtoRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal OrderDeliveryCost { get; set; } = decimal.Zero;
    }
}
