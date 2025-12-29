using AutoMapper;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Enums;
using ProjectTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskEntity = ProjectTracker.Core.Entities.Task;

namespace ProjectTracker.Business.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
        {
            var tasks = await _unitOfWork.Tasks.GetAllAsync();
            
            // Debug: Check if navigation properties are loaded
            foreach (var task in tasks)
            {
                System.Diagnostics.Debug.WriteLine($"Task: {task.TaskName}, Project: {task.Project?.ProjectName ?? "NULL"}, User: {task.AssignedToUser?.FullName ?? "NULL"}");
            }
            
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<TaskDto> GetTaskByIdAsync(int taskId)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(taskId);
            if (task == null) return null;
            return _mapper.Map<TaskDto>(task);
        }

        public async Task<TaskDto> CreateTaskAsync(CreateTaskDto dto)
        {
            var task = _mapper.Map<TaskEntity>(dto);
            
            // TaskEntity içinde CreatedDate varsa set et
            // task.CreatedDate = DateTime.UtcNow;
            
            await _unitOfWork.Tasks.AddAsync(task);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<TaskDto>(task);
        }

        public async Task<TaskDto> UpdateTaskAsync(int taskId, UpdateTaskDto dto)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(taskId);
            if (task == null)
            {
                throw new Exception($"Task with ID {taskId} not found.");
            }

            // Mapper ile güncelleme veya manuel atama
            task.ProjectId = dto.ProjectId;
            task.AssignedToUserId = dto.AssignedUserId;
            task.ParentTaskId = dto.ParentTaskId;
            task.TaskName = dto.TaskName;
            task.Description = dto.Description;
            task.StartDate = dto.StartDate;
            task.DueDate = dto.DueDate;
            task.Status = dto.Status;
            task.Priority = dto.Priority;
            // task.UpdatedDate = DateTime.UtcNow; // Entity'de varsa

            _unitOfWork.Tasks.Update(task);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<TaskDto>(task);
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(taskId);
            if (task != null)
            {
                _unitOfWork.Tasks.Remove(task);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<Dictionary<ProjectTracker.Core.Enums.TaskStatus, int>> GetTaskCountByStatusAsync()
        {
            var tasks = await _unitOfWork.Tasks.GetAllAsync();
            
            return tasks
                .GroupBy(t => t.Status)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
