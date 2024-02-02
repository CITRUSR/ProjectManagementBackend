using FluentValidation;

namespace Application.Project.Commands.DeleteProject;

public class DeleteProjectValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectValidator()
    {
        RuleFor(x => x.ProjectId).NotEmpty();
    }
}