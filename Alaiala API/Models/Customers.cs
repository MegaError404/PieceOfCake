using System.ComponentModel.DataAnnotations;

namespace Alaiala_API.Models
{
    public class Customers
	{
        [Required,Key]
        public int Id { get; set; }
        
        [Required]
        public Guid GUID { get; set; } = Guid.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required,Phone]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
