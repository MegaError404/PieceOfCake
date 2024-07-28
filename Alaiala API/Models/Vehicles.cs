using System.ComponentModel.DataAnnotations;

namespace Alaiala_API.Models
{
    public class Vehicles
    {
        [Required, Key]
        public int ID { get; set; } 
      
        [Required]
        public Guid GUID { get; set; } = Guid.Empty;

        [
          Required,
          MaxLength(100,ErrorMessage = "Max Length in Vehicle Name 100 Character"),
          MinLength(4, ErrorMessage= "Min Length in Vehicle Name 4 Character")
        ]
        public string Name { get; set; } = string.Empty;
    }
}