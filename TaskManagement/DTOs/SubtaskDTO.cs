using System;
namespace TaskManagement.DTOs
{
	public class SubtaskDTO
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsCompleted { get; set; }
        public int ParentTaskId { get; set; }
        public string? ParentTaskName { get; set; }
        public string? ParentTaskDescription { get; set; }
        public bool? ParentIsCompleted { get; set; }
    }
}

