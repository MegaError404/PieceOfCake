using System.ComponentModel.DataAnnotations;

namespace Alaiala_API.Models
{
    public class General
	{
        [Required,Key]
        public int Id { get; set; }
        
        [Required]
		public Guid GUID { get; set; } = Guid.Empty;

        [Required(ErrorMessage = "Key General Is Required")]
        public string Key { get; set; } = string.Empty;

        [Required(ErrorMessage = "Value General Is Required")]
        public string Value { get; set; } = string.Empty;
    }
}