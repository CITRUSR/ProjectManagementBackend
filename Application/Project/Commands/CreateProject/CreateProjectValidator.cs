using System.Data;
using FluentValidation;

namespace Application.Project.Commands;

public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.DateStart).NotEmpty();
        RuleFor(x => x.DateEnd).NotEmpty();
    }
}