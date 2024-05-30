using System;
using TaskManagement.DTOs;

using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Repositories.Interfaces
{
	public interface ITaskRepository
	{
		Task<IEnumerable<Models.Task>> GetAllTasks();
		Task<Models.Task> GetTaskById(int id);
		Task AddTask(TaskRequestDTO request);
		Task UpdateTask(TaskRequestDTO request, int id);
		Task DeleteTask(int id);
		Task<IEnumerable<Models.Task>> GetCompletedTasks();

		Task<string> AssignTaskToUser(Models.Task task, string username);

		Task<string> CompleteTask(Models.Task task);
    }
}

