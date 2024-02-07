using Application.Common.Mappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Project.Queries.GetAllProjects;

public class GetAllProjectsQueryHandler(IAppDbContext dbContext, ProjectMapper mapper)
    : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
{
    private readonly IAppDbContext _dbContext = dbContext;
    private readonly ProjectMapper _mapper = mapper;

    public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        List<ProjectViewModel> projects = await _dbContext.Projects.Select(x => _mapper.Map(x)).ToListAsync(cancellationToken);

        return projects;
    }
}