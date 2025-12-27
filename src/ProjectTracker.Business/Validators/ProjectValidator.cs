using FluentValidation;
using ProjectTracker.Business.DTOs;

namespace ProjectTracker.Business.Validators
{
    /// <summary>
    /// Validator for ProjectDto
    /// </summary>
    public class ProjectValidator : AbstractValidator<ProjectDto>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.ProjectName)
                .NotEmpty().WithMessage("Project name is required")
                .MaximumLength(200).WithMessage("Project name cannot exceed 200 characters");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate)
                .When(x => x.EndDate.HasValue)
                .WithMessage("End date must be after start date");

            RuleFor(x => x.Budget)
                .GreaterThanOrEqualTo(0)
                .When(x => x.Budget.HasValue)
                .WithMessage("Budget cannot be negative");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required")
                .IsInEnum().WithMessage("Invalid project status");

            RuleFor(x => x.CompletionPercentage)
                .InclusiveBetween(0, 100)
                .WithMessage("Completion percentage must be between 0 and 100");
        }
    }
}