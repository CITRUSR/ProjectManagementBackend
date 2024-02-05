using MediatR;

namespace Application.Task.Queries.GetTaskById;

public record GetTaskByIdQuery(Guid Id) : IRequest<TaskViewModel>;