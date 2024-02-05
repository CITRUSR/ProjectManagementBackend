using Domain.Enum;
using MediatR;

namespace Application.Task.Commands.UpdateTask;

public record UpdateTaskCommand(
    Guid Id,
    Guid OwnerId,
    string Title,
    WorkStatus Status,
    Priority Priority,
    DateTime DateStart,
    DateTime DateEnd) : IRequest<TaskViewModel>;