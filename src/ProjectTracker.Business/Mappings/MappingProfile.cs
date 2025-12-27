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
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedProjects, opt => opt.Ignore())
                .ForMember(dest => dest.AssignedTasks, opt => opt.Ignore())
                .ForMember(dest => dest.TeamMemberships, opt => opt.Ignore())
                .ForMember(dest => dest.Notifications, opt => opt.Ignore())
                .ForMember(dest => dest.TaskComments, opt => opt.Ignore());

            // ============================================
            // PROJECT MAPPINGS
            // ============================================
            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.CreatedByUserName, opt => opt.MapFrom(src => src.CreatedByUser.FullName))
                .ForMember(dest => dest.TotalTasks, opt => opt.MapFrom(src => src.Tasks.Count))
                .ForMember(dest => dest.CompletedTasks, opt => opt.MapFrom(src => src.Tasks.Count(t => t.Status == Core.Enums.ProjectStatus.Completed)))
                .ForMember(dest => dest.TeamMemberCount, opt => opt.MapFrom(src => src.TeamMembers.Count));

            CreateMap<ProjectDto, Project>()
                .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore())
                .ForMember(dest => dest.Tasks, opt => opt.Ignore())
                .ForMember(dest => dest.TeamMembers, opt => opt.Ignore())
                .ForMember(dest => dest.Risks, opt => opt.Ignore());

            // ============================================
            // TASK MAPPINGS
            // ============================================
            CreateMap<Core.Entities.Task, TaskDto>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.ProjectName))
                .ForMember(dest => dest.AssignedToUserName, opt => opt.MapFrom(src => src.AssignedToUser != null ? src.AssignedToUser.FullName : null));

            CreateMap<TaskDto, Core.Entities.Task>()
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.AssignedToUser, opt => opt.Ignore())
                .ForMember(dest => dest.Comments, opt => opt.Ignore());
        }
    }
}