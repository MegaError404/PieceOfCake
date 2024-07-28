using System.ComponentModel.DataAnnotations;

namespace Alaiala_API.Models
{
    public class Governorates
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public Guid GUID { get; set; } = Guid.Empty;

        [
          Required,
          MaxLength(100, ErrorMessage = "Max Length in Governorate Name 100 Character"),
          MinLength(4, ErrorMessage = "Min Length in Governorate Name 4 Character")
        ]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "DeliveredOrders Delivery Cost Is Required")]
        public decimal OrderDeliveryCost { get; set; } = decimal.Zero;
    }
}