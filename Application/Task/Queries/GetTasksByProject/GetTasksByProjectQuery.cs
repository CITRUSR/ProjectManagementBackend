using MediatR;

namespace Application.Task.Queries.GetTasksByProject;

public record GetTasksByProjectQuery(Guid ProjectId) : IRequest<List<TaskViewModel>>;