using ProjectTracker.Business.DTOs;
using ProjectTracker.Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracker.Business.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        Task<TaskDto> GetTaskByIdAsync(int taskId);
        Task<TaskDto> CreateTaskAsync(CreateTaskDto dto);
        Task<TaskDto> UpdateTaskAsync(int taskId, UpdateTaskDto dto);
        Task DeleteTaskAsync(int taskId);
        Task<Dictionary<ProjectTracker.Core.Enums.TaskStatus, int>> GetTaskCountByStatusAsync();
    }
}
