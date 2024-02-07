using Application.Common.Mappers;
using Application.Project;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Queries.GetAllTasks;

public class GetAllTasksQueryHandler(IAppDbContext dbContext, TaskMapper mapper)
    : IRequestHandler<GetAllTasksQuery, List<TaskViewModel>>
{
    private readonly IAppDbContext _dbContext = dbContext;
    private readonly TaskMapper _mapper = mapper;

    public Task<List<TaskViewModel>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.Tasks.Select(x => _mapper.Map(x)).ToListAsync(cancellationToken);
    }
}