using PieceOfCakeAPI.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PieceOfCakeAPI.Models.Captains
{
	public class CaptainWorkflow
	{
		[Required, Key]
		public int Id { get; set; }

		[Required]
		public Guid GUID { get; set; } = Guid.Empty;

		[Required]
		public DateTime SubmitDate { get; set; } = DateTime.MaxValue;

		[Required]
		public WorkflowSubmitType SubmitType { get; set; } = WorkflowSubmitType.None;

		[Required]
		public Captains Captain { get; set; }
	}
}
