using System;
namespace TaskManagement.DTOs
{
	public class TaskDTO
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public bool? IsCompleted { get; set; }
		public string? Username { get; set; }
	}
}

