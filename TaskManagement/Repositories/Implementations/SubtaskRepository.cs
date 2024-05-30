using System;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.DTOs;
using TaskManagement.Models;
using TaskManagement.Repositories.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Repositories.Implementations
{
	public class SubtaskRepository : ISubtaskRepository
	{
		private readonly AppDbContext _context;
		public SubtaskRepository(AppDbContext context)
		{
			_context = context;
		}

        public Task AddSubtask(SubtaskRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<SubtaskDTO> GetSubtask(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Subtask>> GetSubtaskForATask(int taskId)
        {
            return await _context.SubTasks
                .Where(element => element.TaskId == taskId)
                .ToListAsync();
        }

    }
}

