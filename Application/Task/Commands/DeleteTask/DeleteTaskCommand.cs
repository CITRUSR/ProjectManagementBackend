using MediatR;

namespace Application.Task.Commands.DeleteTask;

public record DeleteTaskCommand(Guid Id) : IRequest;