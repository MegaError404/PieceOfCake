using System.ComponentModel.DataAnnotations;

namespace Alaiala_API.Models.Captains
{
    public class CaptainsNotes
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required(ErrorMessage ="Note Is Required")]
		public string Note { get; set; } = string.Empty;

        [Required]
        public Captains Captain { get; set; }
    }
}
