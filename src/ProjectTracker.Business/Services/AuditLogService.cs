using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;
using ProjectTracker.Core.Interfaces;
using System.Text.Json;

namespace ProjectTracker.Business.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuditLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async System.Threading.Tasks.Task LogActivityAsync(
            ActivityType activityType,
            string tableName,
            int recordId,
            int userId,
            string? oldValues = null,
            string? newValues = null,
            int? teamId = null)
        {
            var log = new AuditLog
            {
                TableName = tableName,
                RecordId = recordId,
                Action = activityType.ToString(),
                OldValues = oldValues,
                NewValues = newValues != null 
                    ? JsonSerializer.Serialize(new { TeamId = teamId, Data = newValues })
                    : (teamId.HasValue ? JsonSerializer.Serialize(new { TeamId = teamId }) : null),
                PerformedByUserId = userId,
                PerformedAt = DateTime.Now
            };

            await _unitOfWork.AuditLogs.AddAsync(log);
            await _unitOfWork.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task<IEnumerable<ActivityDto>> GetAllRecentActivitiesAsync(int count = 20)
        {
            var logs = await _unitOfWork.AuditLogs.GetAllAsync();
            var recentLogs = logs
                .OrderByDescending(l => l.PerformedAt)
                .Take(count)
                .ToList();

            return await MapToActivityDtosAsync(recentLogs);
        }

        public async System.Threading.Tasks.Task<IEnumerable<ActivityDto>> GetTeamActivitiesAsync(
            IEnumerable<int> teamIds, int count = 20)
        {
            var teamIdList = teamIds.ToList();
            
            // Get projects belonging to these teams
            var projects = await _unitOfWork.Projects
                .FindAsync(p => teamIdList.Contains(p.TeamId));
            var projectIds = projects.Select(p => p.ProjectId).ToList();

            // Get tasks belonging to these projects
            var tasks = await _unitOfWork.Tasks
                .FindAsync(t => projectIds.Contains(t.ProjectId));
            var taskIds = tasks.Select(t => t.TaskId).ToList();

            // Get logs for these entities
            var logs = await _unitOfWork.AuditLogs.GetAllAsync();
            var filteredLogs = logs
                .Where(l => 
                    (l.TableName == "Projects" && projectIds.Contains(l.RecordId)) ||
                    (l.TableName == "Tasks" && taskIds.Contains(l.RecordId)) ||
                    (l.TableName == "Teams" && teamIdList.Contains(l.RecordId)))
                .OrderByDescending(l => l.PerformedAt)
                .Take(count)
                .ToList();

            return await MapToActivityDtosAsync(filteredLogs);
        }

        public async System.Threading.Tasks.Task<IEnumerable<ActivityDto>> GetUserRecentActivitiesAsync(
            int userId, bool isAdmin, int count = 20)
        {
            if (isAdmin)
            {
                return await GetAllRecentActivitiesAsync(count);
            }

            // Get user's teams
            var userTeams = await _unitOfWork.TeamMembers
                .FindAsync(tm => tm.UserId == userId && tm.IsActive);
            var teamIds = userTeams.Select(tm => tm.TeamId).ToList();

            return await GetTeamActivitiesAsync(teamIds, count);
        }

        public async System.Threading.Tasks.Task<IEnumerable<ActivityDto>> GetProjectActivitiesAsync(int projectId, int count = 50)
        {
            // Get tasks for this project
            var tasks = await _unitOfWork.Tasks.FindAsync(t => t.ProjectId == projectId);
            var taskIds = tasks.Select(t => t.TaskId).ToList();

            var logs = await _unitOfWork.AuditLogs.GetAllAsync();
            var filteredLogs = logs
                .Where(l => 
                    (l.TableName == "Projects" && l.RecordId == projectId) ||
                    (l.TableName == "Tasks" && taskIds.Contains(l.RecordId)))
                .OrderByDescending(l => l.PerformedAt)
                .Take(count)
                .ToList();

            return await MapToActivityDtosAsync(filteredLogs);
        }

        public async System.Threading.Tasks.Task<IEnumerable<ActivityDto>> GetTaskActivitiesAsync(int taskId, int count = 20)
        {
            var logs = await _unitOfWork.AuditLogs.GetAllAsync();
            var filteredLogs = logs
                .Where(l => l.TableName == "Tasks" && l.RecordId == taskId)
                .OrderByDescending(l => l.PerformedAt)
                .Take(count)
                .ToList();

            return await MapToActivityDtosAsync(filteredLogs);
        }

        private async System.Threading.Tasks.Task<IEnumerable<ActivityDto>> MapToActivityDtosAsync(List<AuditLog> logs)
        {
            var activities = new List<ActivityDto>();

            foreach (var log in logs)
            {
                var user = log.PerformedByUserId.HasValue 
                    ? await _unitOfWork.Users.GetByIdAsync(log.PerformedByUserId.Value)
                    : null;

                var activity = new ActivityDto
                {
                    LogId = log.LogId,
                    UserId = log.PerformedByUserId ?? 0,
                    UserName = user?.FullName ?? "System",
                    ActionType = log.Action,
                    PerformedAt = log.PerformedAt
                };

                // Get target name and details based on table
                await EnrichActivityDto(activity, log);

                activities.Add(activity);
            }

            return activities;
        }

        private async System.Threading.Tasks.Task EnrichActivityDto(ActivityDto activity, AuditLog log)
        {
            switch (log.TableName)
            {
                case "Tasks":
                    var task = await _unitOfWork.Tasks.GetByIdAsync(log.RecordId);
                    activity.TargetName = task?.TaskName ?? $"Task #{log.RecordId}";
                    if (task != null)
                    {
                        var project = await _unitOfWork.Projects.GetByIdAsync(task.ProjectId);
                        activity.ProjectName = project?.ProjectName;
                        activity.TeamId = project?.TeamId;
                    }
                    activity.Icon = GetTaskIcon(log.Action);
                    activity.ActionDescription = GetTaskActionDescription(log.Action);
                    break;

                case "Projects":
                    var proj = await _unitOfWork.Projects.GetByIdAsync(log.RecordId);
                    activity.TargetName = proj?.ProjectName ?? $"Project #{log.RecordId}";
                    activity.ProjectName = proj?.ProjectName;
                    activity.TeamId = proj?.TeamId;
                    activity.Icon = GetProjectIcon(log.Action);
                    activity.ActionDescription = GetProjectActionDescription(log.Action);
                    break;

                case "Teams":
                    var team = await _unitOfWork.Teams.GetByIdAsync(log.RecordId);
                    activity.TargetName = team?.TeamName ?? $"Team #{log.RecordId}";
                    activity.TeamId = log.RecordId;
                    activity.Icon = GetTeamIcon(log.Action);
                    activity.ActionDescription = GetTeamActionDescription(log.Action);
                    break;

                default:
                    activity.TargetName = $"{log.TableName} #{log.RecordId}";
                    activity.Icon = "📝";
                    activity.ActionDescription = log.Action.ToLower();
                    break;
            }
        }

        private string GetTaskIcon(string action) => action switch
        {
            "TaskCompleted" => "✅",
            "TaskCreated" => "➕",
            "TaskAssigned" => "👤",
            "TaskDeleted" => "🗑️",
            "TaskStatusChanged" => "🔄",
            "TaskPriorityChanged" => "⚡",
            _ => "📋"
        };

        private string GetTaskActionDescription(string action) => action switch
        {
            "TaskCompleted" => "completed task",
            "TaskCreated" => "created task",
            "TaskAssigned" => "assigned task",
            "TaskUnassigned" => "unassigned task",
            "TaskDeleted" => "deleted task",
            "TaskStatusChanged" => "changed task status",
            "TaskPriorityChanged" => "changed task priority",
            "TaskUpdated" => "updated task",
            _ => "modified task"
        };

        private string GetProjectIcon(string action) => action switch
        {
            "ProjectCompleted" => "🎉",
            "ProjectCreated" => "📁",
            "ProjectDeleted" => "🗑️",
            "ProjectStatusChanged" => "🔄",
            _ => "📂"
        };

        private string GetProjectActionDescription(string action) => action switch
        {
            "ProjectCompleted" => "completed project",
            "ProjectCreated" => "created project",
            "ProjectDeleted" => "deleted project",
            "ProjectStatusChanged" => "changed project status",
            "ProjectUpdated" => "updated project",
            _ => "modified project"
        };

        private string GetTeamIcon(string action) => action switch
        {
            "TeamCreated" => "🏢",
            "MemberAdded" => "👥",
            "MemberRemoved" => "👤",
            "MemberRoleChanged" => "🔑",
            _ => "🏢"
        };

        private string GetTeamActionDescription(string action) => action switch
        {
            "TeamCreated" => "created team",
            "TeamUpdated" => "updated team",
            "TeamDeleted" => "deleted team",
            "MemberAdded" => "added member to team",
            "MemberRemoved" => "removed member from team",
            "MemberRoleChanged" => "changed member role",
            _ => "modified team"
        };
    }
}
