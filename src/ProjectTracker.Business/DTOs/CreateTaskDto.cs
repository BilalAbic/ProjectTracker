using ProjectTracker.Core.Enums;
using System;
using TaskStatusEnum = ProjectTracker.Core.Enums.TaskStatus;

namespace ProjectTracker.Business.DTOs
{
    public class CreateTaskDto
    {
        public int ProjectId { get; set; }
        public int? AssignedUserId { get; set; }
        public int? ParentTaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskStatusEnum Status { get; set; }
        public Priority Priority { get; set; }
    }
}
