using FluentValidation;

namespace Application.Project.Commands.UpdateProject;

public class UpdateProjectValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectValidator()
    {
        RuleFor(x => x.DateStart).NotEmpty();
        RuleFor(x => x.DateEnd).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Status).NotEmpty();
        RuleFor(x => x.OwnerId).NotEmpty();
        RuleFor(x => x.ProjectId).NotEmpty();
    }
}