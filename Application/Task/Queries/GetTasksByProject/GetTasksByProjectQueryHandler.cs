using Application.Common.Mappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Queries.GetTasksByProject;

public class GetTasksByProjectQueryHandler(IAppDbContext dbContext, TaskMapper mapper)
    : IRequestHandler<GetTasksByProjectQuery, List<TaskViewModel>>
{
    private readonly IAppDbContext _dbContext = dbContext;
    private readonly TaskMapper _mapper = mapper;

    public Task<List<TaskViewModel>> Handle(GetTasksByProjectQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.Tasks.Where(x => x.ProjectId == request.ProjectId).Select(x => _mapper.Map(x))
            .ToListAsync(cancellationToken);
    }
}