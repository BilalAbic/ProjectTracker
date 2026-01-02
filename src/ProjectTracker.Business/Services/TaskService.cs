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
        private readonly IAuditLogService _auditLogService;
        private readonly ICurrentUserService _currentUserService;

        public TaskService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IAuditLogService auditLogService,
            ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _auditLogService = auditLogService;
            _currentUserService = currentUserService;
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
            
            await _unitOfWork.Tasks.AddAsync(task);
            await _unitOfWork.SaveChangesAsync();

            // Log activity (fire-and-forget)
            var projectId = task.ProjectId;
            var taskId = task.TaskId;
            _ = System.Threading.Tasks.Task.Run(async () =>
            {
                try
                {
                    var project = await _unitOfWork.Projects.GetByIdAsync(projectId);
                    await _auditLogService.LogActivityAsync(
                        ActivityType.TaskCreated,
                        "Tasks",
                        taskId,
                        _currentUserService.CurrentUserId,
                        teamId: project?.TeamId);
                }
                catch { /* Ignore */ }
            });

            return _mapper.Map<TaskDto>(task);
        }

        public async Task<TaskDto> UpdateTaskAsync(int taskId, UpdateTaskDto dto)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(taskId);
            if (task == null)
            {
                throw new Exception($"Task with ID {taskId} not found.");
            }

            var oldStatus = task.Status;
            var oldAssignee = task.AssignedToUserId;

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

            _unitOfWork.Tasks.Update(task);
            await _unitOfWork.SaveChangesAsync();

            // Log appropriate activity (fire-and-forget)
            var projectId = task.ProjectId;
            _ = System.Threading.Tasks.Task.Run(async () =>
            {
                try
                {
                    var project = await _unitOfWork.Projects.GetByIdAsync(projectId);
                    
                    if (oldStatus != dto.Status)
                    {
                        var activityType = dto.Status == Core.Enums.TaskStatus.Completed 
                            ? ActivityType.TaskCompleted 
                            : ActivityType.TaskStatusChanged;
                            
                        await _auditLogService.LogActivityAsync(
                            activityType, "Tasks", taskId,
                            _currentUserService.CurrentUserId,
                            oldValues: oldStatus.ToString(),
                            newValues: dto.Status.ToString(),
                            teamId: project?.TeamId);
                    }
                    else if (oldAssignee != dto.AssignedUserId)
                    {
                        await _auditLogService.LogActivityAsync(
                            dto.AssignedUserId.HasValue ? ActivityType.TaskAssigned : ActivityType.TaskUnassigned,
                            "Tasks", taskId,
                            _currentUserService.CurrentUserId,
                            teamId: project?.TeamId);
                    }
                    else
                    {
                        await _auditLogService.LogActivityAsync(
                            ActivityType.TaskUpdated,
                            "Tasks", taskId,
                            _currentUserService.CurrentUserId,
                            teamId: project?.TeamId);
                    }
                }
                catch { /* Ignore */ }
            });

            return _mapper.Map<TaskDto>(task);
        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(int taskId)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(taskId);
            if (task != null)
            {
                var projectId = task.ProjectId;
                
                _unitOfWork.Tasks.Remove(task);
                await _unitOfWork.SaveChangesAsync();

                // Log activity (fire-and-forget)
                _ = System.Threading.Tasks.Task.Run(async () =>
                {
                    try
                    {
                        var project = await _unitOfWork.Projects.GetByIdAsync(projectId);
                        await _auditLogService.LogActivityAsync(
                            ActivityType.TaskDeleted,
                            "Tasks",
                            taskId,
                            _currentUserService.CurrentUserId,
                            teamId: project?.TeamId);
                    }
                    catch { /* Ignore */ }
                });
            }
        }

        public async Task<Dictionary<ProjectTracker.Core.Enums.TaskStatus, int>> GetTaskCountByStatusAsync()
        {
            var tasks = await _unitOfWork.Tasks.GetAllAsync();
            
            return tasks
                .GroupBy(t => t.Status)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Get tasks for specific projects
        /// </summary>
        public async Task<IEnumerable<TaskDto>> GetTasksByProjectsAsync(IEnumerable<int> projectIds)
        {
            var projectIdList = projectIds.ToList();
            var tasks = await _unitOfWork.Tasks.FindAsync(t => projectIdList.Contains(t.ProjectId));
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        /// <summary>
        /// Get tasks for current user based on team membership
        /// </summary>
        public async Task<IEnumerable<TaskDto>> GetUserTasksAsync(int userId)
        {
            // 1. Get user's team memberships
            var userTeams = await _unitOfWork.TeamMembers
                .FindAsync(tm => tm.UserId == userId && tm.IsActive);
            var teamIds = userTeams.Select(tm => tm.TeamId).ToList();

            // 2. Get projects belonging to those teams
            var projects = await _unitOfWork.Projects.FindAsync(p => teamIds.Contains(p.TeamId));
            var projectIds = projects.Select(p => p.ProjectId).ToList();

            // 3. Get tasks belonging to those projects
            var tasks = await _unitOfWork.Tasks.FindAsync(t => projectIds.Contains(t.ProjectId));
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }
    }
}
