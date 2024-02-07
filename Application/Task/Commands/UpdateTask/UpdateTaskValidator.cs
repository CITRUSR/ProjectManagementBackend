using Application.Task.Commands.CreateTask;
using FluentValidation;

namespace Application.Task.Commands.UpdateTask;

public class UpdateTaskValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskValidator()
    {
        RuleFor(x => x.OwnerId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.DateStart).NotEmpty();
        RuleFor(x => x.DateEnd).NotEmpty();
    }
}