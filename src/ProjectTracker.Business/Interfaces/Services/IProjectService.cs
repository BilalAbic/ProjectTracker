using ProjectTracker.Business.DTOs;

namespace ProjectTracker.Business.Interfaces
{
    /// <summary>
    /// Project service interface - manages project operations
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Get project by ID with related data
        /// </summary>
        Task<ProjectDto?> GetProjectByIdAsync(int projectId);

        /// <summary>
        /// Get all projects
        /// </summary>
        Task<IEnumerable<ProjectDto>> GetAllAsync();

        /// <summary>
        /// Get active projects only
        /// </summary>
        Task<IEnumerable<ProjectDto>> GetActiveProjectsAsync();

        /// <summary>
        /// Get projects created by specific user
        /// </summary>
        Task<IEnumerable<ProjectDto>> GetProjectsByUserAsync(int userId);

        /// <summary>
        /// Create a new project
        /// </summary>
        Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto);

        /// <summary>
        /// Update existing project
        /// </summary>
        Task<ProjectDto> UpdateProjectAsync(ProjectDto projectDto);

        /// <summary>
        /// Delete project
        /// </summary>
        Task<bool> DeleteProjectAsync(int projectId);

        /// <summary>
        /// Calculate project risk score (Smart Algorithm)
        /// </summary>
        Task<decimal> CalculateProjectRiskAsync(int projectId);

        /// <summary>
        /// Update project completion percentage
        /// </summary>
        Task UpdateProjectCompletionAsync(int projectId);
    }
}