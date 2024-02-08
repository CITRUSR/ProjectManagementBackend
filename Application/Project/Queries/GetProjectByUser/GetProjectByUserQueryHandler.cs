using Application.Common.Exceptions;
using Application.Common.Mappers;
using Domain;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Project.Queries.GetProjectByUser;

public class GetProjectByUserQueryHandler(
    IAppDbContext dbContext,
    ProjectMapper mapper)
    : IRequestHandler<GetProjectByUserQuery, ProjectViewModel>
{
    private readonly IAppDbContext _dbContext = dbContext;
    private readonly ProjectMapper _mapper = mapper;

    public async Task<ProjectViewModel> Handle(GetProjectByUserQuery request, CancellationToken cancellationToken)
    {
        var project =
            await _dbContext.Projects.FirstOrDefaultAsync(x => x.OwnerId == request.UserId,
                cancellationToken);

        if (project == null)
        {
            throw new NotFoundException($"The user with the id:{request.UserId} doesn't have a project");
        }


        return _mapper.Map(project);
    }
}