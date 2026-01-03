using AutoMapper;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Business.Mappings
{
    /// <summary>
    /// AutoMapper profile for Entity to DTO mappings
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ============================================
            // USER MAPPINGS
            // ============================================
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.GitHubUsername, opt => opt.MapFrom(src => src.GitHubUsername))
                .ForMember(dest => dest.GitHubAvatarUrl, opt => opt.MapFrom(src => src.GitHubAvatarUrl));

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedProjects, opt => opt.Ignore())
                .ForMember(dest => dest.AssignedTasks, opt => opt.Ignore())
                .ForMember(dest => dest.TeamMemberships, opt => opt.Ignore())
                .ForMember(dest => dest.Notifications, opt => opt.Ignore())
                .ForMember(dest => dest.TaskComments, opt => opt.Ignore())
                .ForMember(dest => dest.GitHubTokens, opt => opt.Ignore());

            // ============================================
            // PROJECT MAPPINGS
            // ============================================
            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.CreatedByUserName, opt => opt.MapFrom(src => src.CreatedByUser.FullName))
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team != null ? src.Team.TeamName : null))
                .ForMember(dest => dest.TotalTasks, opt => opt.MapFrom(src => src.Tasks.Count))
                .ForMember(dest => dest.CompletedTasks, opt => opt.MapFrom(src => src.Tasks.Count(t => t.Status == Core.Enums.TaskStatus.Completed)))
                .ForMember(dest => dest.TeamMemberCount, opt => opt.MapFrom(src => src.TeamMembers.Count));

            CreateMap<ProjectDto, Project>()
                .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore())
                .ForMember(dest => dest.Team, opt => opt.Ignore())
                .ForMember(dest => dest.Tasks, opt => opt.Ignore())
                .ForMember(dest => dest.TeamMembers, opt => opt.Ignore())
                .ForMember(dest => dest.Risks, opt => opt.Ignore());

            // ============================================
            // TASK MAPPINGS
            // ============================================
            CreateMap<Core.Entities.Task, TaskDto>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project != null ? src.Project.ProjectName : null))
                .ForMember(dest => dest.AssignedToUserName, opt => opt.MapFrom(src => src.AssignedToUser != null ? src.AssignedToUser.FullName : null))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<TaskDto, Core.Entities.Task>()
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.AssignedToUser, opt => opt.Ignore())
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => 
                    string.IsNullOrEmpty(src.Priority) ? Core.Enums.Priority.Medium : Enum.Parse<Core.Enums.Priority>(src.Priority)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 
                    string.IsNullOrEmpty(src.Status) ? Core.Enums.TaskStatus.Pending : Enum.Parse<Core.Enums.TaskStatus>(src.Status)));
        }
    }
}