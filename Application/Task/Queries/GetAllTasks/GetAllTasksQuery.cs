using MediatR;

namespace Application.Task.Queries.GetAllTasks;

public record GetAllTasksQuery() : IRequest<List<TaskViewModel>>;