namespace Alaiala_API.Models
{
    public class ApiResponse<T>
	{
		public T Data { get; set; }
		public bool Success { get; set; } = true;
		public string Message { get; set; } = string.Empty;
	}
}
