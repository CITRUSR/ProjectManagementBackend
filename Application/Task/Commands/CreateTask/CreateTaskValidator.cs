using System.Data;
using FluentValidation;

namespace Application.Task.Commands.CreateTask;

public class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.ProjectId).NotEmpty();
        RuleFor(x => x.OwnerId).NotEmpty();
        RuleFor(x => x.DateStart).NotEmpty();
        RuleFor(x => x.DateEnd).NotEmpty();
    }
}