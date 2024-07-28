using System.ComponentModel.DataAnnotations;

namespace Alaiala_API.Models
{
    public class Admins
    {
        [Required, Key]
        public int Id { get; set; }
        
		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required,MaxLength(100),MinLength(4)]
        public string Name { get; set; } = string.Empty;

		[Required]
		public byte[] PasswordHash { get; set; } = Guid.Empty.ToByteArray();

		[Required]
		public byte[] PasswordSalt { get; set; } = Guid.Empty.ToByteArray();

		[Required,Phone]
		public string PhoneNumber { get; set; } = string.Empty;

		[Required,EmailAddress]
		public string Email { get; set; } = string.Empty;
	}
}
