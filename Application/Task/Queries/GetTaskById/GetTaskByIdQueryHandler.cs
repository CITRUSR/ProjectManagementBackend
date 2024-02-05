using Application.Common.Exceptions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Queries.GetTaskById;

public class GetTaskByIdQueryHandler(IAppDbContext dbContext) : IRequestHandler<GetTaskByIdQuery, TaskViewModel>
{
    private readonly IAppDbContext _dbContext = dbContext;

    public async Task<TaskViewModel> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (task == null)
        {
            throw new NotFoundException($"Task with id:{request.Id} is not found");
        }

        return new TaskViewModel
        {
            Title = task.Title,
            Status = task.Status,
            ProjectId = task.ProjectId,
            Id = task.Id,
            Priority = task.Priority,
            DateStart = task.DateStart,
            DateEnd = task.DateEnd,
            OwnerId = task.OwnerId,
        };
    }
}