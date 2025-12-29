using AutoMapper;
using FluentValidation;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;
using ProjectTracker.Core.Interfaces;

namespace ProjectTracker.Business.Services
{
    /// <summary>
    /// Project service implementation - handles project business logic
    /// </summary>
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ProjectDto> _projectValidator;

        public ProjectService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<ProjectDto> projectValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _projectValidator = projectValidator;
        }

        /// <summary>
        /// Get project by ID
        /// </summary>
        public async Task<ProjectDto?> GetProjectByIdAsync(int projectId)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(projectId);
            if (project == null)
                return null;

            return _mapper.Map<ProjectDto>(project);
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var projects = await _unitOfWork.Projects.GetAllAsync();
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        /// <summary>
        /// Get active projects
        /// </summary>
        public async Task<IEnumerable<ProjectDto>> GetActiveProjectsAsync()
        {
            var projects = await _unitOfWork.Projects.FindAsync(p => p.Status == "Active");
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        /// <summary>
        /// Get projects by user
        /// </summary>
        public async Task<IEnumerable<ProjectDto>> GetProjectsByUserAsync(int userId)
        {
            var projects = await _unitOfWork.Projects.FindAsync(p => p.CreatedByUserId == userId);
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        /// <summary>
        /// Create new project
        /// </summary>
        public async Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto)
        {
            // Validate
            var validationResult = await _projectValidator.ValidateAsync(projectDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // Map DTO to Entity
            var project = _mapper.Map<Project>(projectDto);
            project.CreatedAt = DateTime.Now;
            project.Status = "Planned";
            project.CompletionPercentage = 0;

            // Add to repository
            await _unitOfWork.Projects.AddAsync(project);
            await _unitOfWork.SaveChangesAsync();

            // Return DTO
            return _mapper.Map<ProjectDto>(project);
        }

        /// <summary>
        /// Update project
        /// </summary>
        public async Task<ProjectDto> UpdateProjectAsync(ProjectDto projectDto)
        {
            // Validate
            var validationResult = await _projectValidator.ValidateAsync(projectDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var project = await _unitOfWork.Projects.GetByIdAsync(projectDto.ProjectId);
            if (project == null)
            {
                throw new InvalidOperationException("Project not found");
            }

            // Update properties
            project.ProjectName = projectDto.ProjectName;
            project.Description = projectDto.Description;
            project.StartDate = projectDto.StartDate;
            project.EndDate = projectDto.EndDate;
            project.Budget = projectDto.Budget;
            project.Status = projectDto.Status.ToString();
            project.UpdatedAt = DateTime.Now;

            _unitOfWork.Projects.Update(project);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProjectDto>(project);
        }

        /// <summary>
        /// Delete project
        /// </summary>
        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(projectId);
            if (project == null)
                return false;

            _unitOfWork.Projects.Remove(project);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Calculate project risk score (Smart Algorithm - MVP version)
        /// </summary>
        public async Task<decimal> CalculateProjectRiskAsync(int projectId)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(projectId);
            if (project == null)
                return 0;

            // Simple risk calculation for MVP
            // TODO: Implement advanced risk algorithm
            decimal riskScore = 0;

            // Factor 1: Completion vs. Time remaining
            if (project.EndDate.HasValue)
            {
                var totalDays = (project.EndDate.Value - project.StartDate).TotalDays;
                var elapsedDays = (DateTime.Now - project.StartDate).TotalDays;
                var expectedCompletion = (decimal)(elapsedDays / totalDays * 100);

                if (project.CompletionPercentage < expectedCompletion)
                {
                    riskScore += (expectedCompletion - project.CompletionPercentage);
                }
            }

            // Factor 2: Task completion rate
            var tasks = await _unitOfWork.Tasks.FindAsync(t => t.ProjectId == projectId);
            var taskCount = tasks.Count();
            if (taskCount > 0)
            {
                var completedCount = tasks.Count(t => t.Status == Core.Enums.TaskStatus.Completed);
                var taskCompletionRate = (decimal)completedCount / taskCount * 100;

                if (taskCompletionRate < 50)
                {
                    riskScore += 20;
                }
            }

            // Normalize to 0-100
            riskScore = Math.Min(riskScore, 100);

            // Update project risk score
            project.RiskScore = riskScore;
            _unitOfWork.Projects.Update(project);
            await _unitOfWork.SaveChangesAsync();

            return riskScore;
        }

        /// <summary>
        /// Update project completion percentage
        /// </summary>
        public async System.Threading.Tasks.Task UpdateProjectCompletionAsync(int projectId)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(projectId);
            if (project == null)
                return;

            var tasks = await _unitOfWork.Tasks.FindAsync(t => t.ProjectId == projectId);
            var taskCount = tasks.Count();

            if (taskCount == 0)
            {
                project.CompletionPercentage = 0;
            }
            else
            {
                var completedCount = tasks.Count(t => t.Status == Core.Enums.TaskStatus.Completed);
                project.CompletionPercentage = (decimal)completedCount / taskCount * 100;
            }

            project.UpdatedAt = DateTime.Now;
            _unitOfWork.Projects.Update(project);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Create new project using CreateProjectDto
        /// </summary>
        public async Task<ProjectDto> CreateProjectAsync(CreateProjectDto dto)
        {
            var project = new Project
            {
                ProjectName = dto.ProjectName,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Status = dto.Status.ToString(),
                Priority = dto.Priority,
                Budget = dto.Budget,
                CreatedByUserId = dto.CreatedByUserId,
                CreatedAt = DateTime.Now,
                CompletionPercentage = 0
            };

            await _unitOfWork.Projects.AddAsync(project);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProjectDto>(project);
        }

        /// <summary>
        /// Update project using UpdateProjectDto
        /// </summary>
        public async Task<ProjectDto> UpdateProjectAsync(int projectId, UpdateProjectDto dto)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(projectId);
            if (project == null)
            {
                throw new InvalidOperationException($"Project with ID {projectId} not found.");
            }

            // Update properties
            project.ProjectName = dto.ProjectName;
            project.Description = dto.Description;
            project.StartDate = dto.StartDate;
            project.EndDate = dto.EndDate;
            project.Status = dto.Status.ToString();
            project.Priority = dto.Priority;
            project.Budget = dto.Budget;
            project.UpdatedAt = DateTime.Now;

            _unitOfWork.Projects.Update(project);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProjectDto>(project);
        }

        /// <summary>
        /// Get projects count by status
        /// </summary>
        public async Task<Dictionary<ProjectStatus, int>> GetProjectCountByStatusAsync()
        {
            var projects = await _unitOfWork.Projects.GetAllAsync();

            var result = new Dictionary<ProjectStatus, int>();
            
            foreach (ProjectStatus status in Enum.GetValues(typeof(ProjectStatus)))
            {
                result[status] = projects.Count(p => p.Status == status.ToString());
            }

            return result;
        }
    }
}
