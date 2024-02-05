using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Queries.GetTasksByProject;

public class GetTasksByProjectQueryHandler(IAppDbContext dbContext)
    : IRequestHandler<GetTasksByProjectQuery, List<TaskViewModel>>
{
    private readonly IAppDbContext _dbContext = dbContext;

    public Task<List<TaskViewModel>> Handle(GetTasksByProjectQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.Tasks.Where(x => x.ProjectId == request.ProjectId).Select(x => new TaskViewModel
        {
            Id = x.Id,
            OwnerId = x.OwnerId,
            ProjectId = x.ProjectId,
            Title = x.Title,
            Priority = x.Priority,
            Status = x.Status,
            DateStart = x.DateStart,
            DateEnd = x.DateEnd,
        }).ToListAsync(cancellationToken);
    }
}