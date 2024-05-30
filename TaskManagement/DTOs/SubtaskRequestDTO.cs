using System;
namespace TaskManagement.DTOs
{
	public class SubtaskRequestDTO
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}

