using System;
using TaskManagement.DTOs;
using TaskManagement.Models;

using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Repositories.Interfaces
{
	public interface ISubtaskRepository
	{
		Task AddSubtask(SubtaskRequestDTO request);

		Task<SubtaskDTO> GetSubtask(int id);

        Task<IEnumerable<Subtask>> GetSubtaskForATask(int taskId);

    }
}

