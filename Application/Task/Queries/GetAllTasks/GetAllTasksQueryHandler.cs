using Application.Project;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Queries.GetAllTasks;

public class GetAllTasksQueryHandler(IAppDbContext dbContext) : IRequestHandler<GetAllTasksQuery, List<TaskViewModel>>
{
    private readonly IAppDbContext _dbContext = dbContext;

    public Task<List<TaskViewModel>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.Tasks.Select(x => new TaskViewModel
        {
            Id = x.Id,
            OwnerId = x.OwnerId,
            ProjectId = x.ProjectId,
            Priority = x.Priority,
            Status = x.Status,
            Title = x.Title,
            DateStart = x.DateStart,
            DateEnd = x.DateEnd,
        }).ToListAsync(cancellationToken);
    }
}