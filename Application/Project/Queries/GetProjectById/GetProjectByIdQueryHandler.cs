using Application.Common.Exceptions;
using Application.Common.Mappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Project.Queries.GetProjectById;

public class GetProjectByIdQueryHandler(IAppDbContext dbContext, ProjectMapper mapper)
    : IRequestHandler<GetProjectByIdQuery, ProjectViewModel>
{
    private readonly IAppDbContext _dbContext = dbContext;
    private readonly ProjectMapper _mapper = mapper;

    public async Task<ProjectViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Project project =
            await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId, cancellationToken);

        if (project == null)
        {
            throw new NotFoundException($"Project with id: {request.ProjectId} not found");
        }

        return _mapper.Map(project);
    }
}