using FluentValidation;

namespace Application.Project.Queries.GetProjectById;

public class GetProjectByIdValidator : AbstractValidator<GetProjectByIdQuery>
{
    public GetProjectByIdValidator()
    {
        RuleFor(x => x.ProjectId).NotEmpty();
    }
}