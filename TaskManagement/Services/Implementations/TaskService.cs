using System;
using AutoMapper;
using TaskManagement.DTOs;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Services.Interfaces;

using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Services.Implementations
{
	public class TaskService : ITaskService
	{
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository,
            IMapper mapper)
		{
            _taskRepository = taskRepository;
            _mapper = mapper;
		}

        public async Task AddTask(TaskRequestDTO request)
        {
            await _taskRepository.AddTask(request);
        }

        public async Task DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(id);
        }


        public async Task<IEnumerable<TaskDTO>> GetCompletedTasks()
        {
            var completedTasks = await _taskRepository.GetCompletedTasks();

            var response = completedTasks?.Select(element =>
            {
                TaskDTO taskDto = new TaskDTO();

                return _mapper.Map(element, taskDto);
            });

            return response;
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAllTasks();

            var response = tasks?.Select(element =>
            {
                TaskDTO taskDto = new TaskDTO();

                return _mapper.Map(element, taskDto);
            });

            return response;
        }

        public async Task<TaskDTO> GetTaskById(int id)
        {
            var task = await _taskRepository.GetTaskById(id);

            TaskDTO taskDto = new TaskDTO();

            //taskDto.Description = task.Description;
            //taskDto.Name = task.Name;
            //taskDto.Id = task.Id;
            //taskDto.IsCompleted = task.IsCompleted;
            //taskDto.Username = task.Username;

            var response = _mapper.Map(task, taskDto);

            return response;
        }

        public async Task UpdateTask(TaskRequestDTO request, int id)
        {
            await _taskRepository.UpdateTask(request, id);
        }

        public async Task<string> AssignTaskToUser(int id, string username)
        {
            var task = await _taskRepository.GetTaskById(id);

            if (task == null)
            {
                return "Task does not exist.";
            }

            if (!String.IsNullOrEmpty(task.Username))
            {
                return "Task is already assigned";
            }

            return await _taskRepository.AssignTaskToUser(task, username);
        }

        public async Task<string> CompleteTask(int id)
        {
            var task = await _taskRepository.GetTaskById(id);

            if (task == null)
            {
                return "Task does not exist";
            }

            if (task.IsCompleted == true)
            {
                return "Task is already completed";
            }

            return await  _taskRepository.CompleteTask(task);
        }
    }
}

