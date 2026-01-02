using FluentValidation;
using ProjectTracker.Business.DTOs;

namespace ProjectTracker.Business.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters")
                .Matches(@"^[a-zA-Z0-9_]+$")
                    .WithMessage("Username can only contain letters, numbers, and underscores");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required")
                .Length(2, 100).WithMessage("Full name must be between 2 and 100 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Please confirm your password")
                .Equal(x => x.Password).WithMessage("Passwords do not match");

            // RoleId validation: 2=ProjectManager, 3=Developer, 4=Pending
            // Note: RoleId is now set automatically by UserService based on invitation token
            // 4 (Pending) is the default for users without invitation
            RuleFor(x => x.RoleId)
                .InclusiveBetween(2, 4).WithMessage("Invalid role selection");
        }
    }
}
