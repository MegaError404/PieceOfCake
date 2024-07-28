using System.ComponentModel.DataAnnotations;

namespace Alaiala_API.Models
{
    public class Subscriptions
	{
        [Required,Key]
        public int Id { get; set; }
        
        [Required]
        public Guid GUID { get; set; } = Guid.Empty;

        [
          Required,
          MaxLength(100, ErrorMessage = "Max Length in Subscription Name 100 Character"),
          MinLength(4, ErrorMessage = "Min Length in Subscription Name 4 Character")
        ]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Cost { get; set; } = decimal.Zero;

        [Required]
        public int Duration { get; set; } = 0;
    }
}