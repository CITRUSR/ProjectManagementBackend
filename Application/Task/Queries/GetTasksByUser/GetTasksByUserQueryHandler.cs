using Domain;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Queries.GetTasksByUser;

public class GetTasksByUserQueryHandler(
    IAppDbContext dbContext
)
    : IRequestHandler<GetTasksByUserQuery, List<TaskViewModel>>
{
    private readonly IAppDbContext _dbContext = dbContext;

    public async Task<List<TaskViewModel>> Handle(GetTasksByUserQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.Tasks.Where(x => x.OwnerId == request.OwnerId).Select(x => new TaskViewModel
        {
            Id = x.Id,
            OwnerId = x.OwnerId,
            ProjectId = x.ProjectId,
            Title = x.Title,
            DateStart = x.DateStart,
            DateEnd = x.DateEnd,
            Status = x.Status,
            Priority = x.Priority,
        }).ToList();
    }
}