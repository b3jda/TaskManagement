using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
	public class Task
	{
		[Key]
		public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }

        public DateTime CompletedDate { get; set; }
        public string? Username { get; set; }

        public ICollection<Subtask> Subtasks { get; set; }
    }
}

