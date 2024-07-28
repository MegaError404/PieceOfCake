using System.ComponentModel.DataAnnotations;

namespace Alaiala_API.Models
{
    public class Advertisements
	{
        [Required,Key]
        public int Id { get; set; } 
        
        [Required]
        public Guid GUID { get; set; } = Guid.Empty;

        [Required]
        public byte[] Photo { get; set; } 

    }
}
