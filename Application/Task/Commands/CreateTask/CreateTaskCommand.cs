using Domain.Enum;
using MediatR;

namespace Application.Task.Commands.CreateTask;

public record CreateTaskCommand(
    Guid ProjectId,
    Guid OwnerId,
    string Title,
    WorkStatus Status,
    Priority Priority,
    DateTime DateStart,
    DateTime DateEnd) : IRequest<Guid>;