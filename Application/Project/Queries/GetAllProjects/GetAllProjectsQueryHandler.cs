using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Project.Queries.GetAllProjects;

public class GetAllProjectsQueryHandler(IAppDbContext dbContext)
    : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
{
    private readonly IAppDbContext _dbContext = dbContext;

    public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        List<ProjectViewModel> projects = await _dbContext.Projects.Select(x => new ProjectViewModel
        {
            Id = x.Id,
            Title = x.Title,
            DateEnd = x.DateEnd,
            DateStart = x.DateStart,
        }).ToListAsync(cancellationToken);

        return projects;
    }
}