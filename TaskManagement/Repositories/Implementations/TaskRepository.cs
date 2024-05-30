using System;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.DTOs;
using TaskManagement.Repositories.Interfaces;

using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Repositories.Implementations
{
	public class TaskRepository : ITaskRepository
	{
        private readonly AppDbContext _context;

		public TaskRepository(AppDbContext context)
		{
            _context = context;
		}

        public async Task AddTask(TaskRequestDTO request)
        {
            Models.Task requestBody = new Models.Task();

            requestBody.Description = request.Description;
            requestBody.Deadline = request.Deadline;
            requestBody.Name = request.Name;
            requestBody.IsCompleted = request.IsCompleted;

            _context.Tasks.Add(requestBody);
            await _context.SaveChangesAsync();
        }

        public async Task<string> AssignTaskToUser(Models.Task task, string username)
        {
            task.Username = username;

            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return "Successfully assigned";
        }

        public async Task<string> CompleteTask(Models.Task task)
        {
            task.IsCompleted = true;
            task.CompletedDate = DateTime.UtcNow;

            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return "Task successfully completed";

        }

        public async Task DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Models.Task>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<IEnumerable<Models.Task>> GetCompletedTasks()
        {
            return await _context
                .Tasks
                .Where(element => element.IsCompleted == true)
                .ToListAsync();
        }

        public async Task<Models.Task> GetTaskById(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            return task ?? new Models.Task() ;
        }

        public async Task UpdateTask(TaskRequestDTO request, int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task != null)
            {
                task.Description = request.Description;
                task.Deadline = request.Deadline;
                task.Name = request.Name;
                task.IsCompleted = request.IsCompleted;

                _context.Entry(task).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}

