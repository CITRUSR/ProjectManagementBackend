using MediatR;

namespace Application.Task.Queries.GetTasksByUser;

public record GetTasksByUserQuery(Guid OwnerId) : IRequest<List<TaskViewModel>>;