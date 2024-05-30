using System;
using TaskManagement.DTOs;

using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Services.Interfaces
{
	public interface ITaskService
	{
		Task<IEnumerable<TaskDTO>> GetAllTasks();

		Task<TaskDTO> GetTaskById(int id);

		Task UpdateTask(TaskRequestDTO request, int id);
		Task AddTask(TaskRequestDTO request);

		Task DeleteTask(int id);
		Task<IEnumerable<TaskDTO>> GetCompletedTasks();

		Task<string> AssignTaskToUser(int id, string username);

		Task<string> CompleteTask(int id);

    }
}

