using System;
namespace TaskManagement.DTOs
{
	public class TaskRequestDTO
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
    }
}

