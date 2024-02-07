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
    UserManager<AppUser> userManager,
    IHttpContextAccessor accessor,
    ProjectMapper mapper)
    : IRequestHandler<GetProjectByUserQuery, ProjectViewModel>
{
    private readonly IAppDbContext _dbContext = dbContext;
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly IHttpContextAccessor _accessor = accessor;
    private readonly ProjectMapper _mapper = mapper;

    public async Task<ProjectViewModel> Handle(GetProjectByUserQuery request, CancellationToken cancellationToken)
    {
        if (!accessor.HttpContext.User.Identity.IsAuthenticated)
        {
            throw new IdentityException("User is not authorized");
        }

        var user = await _userManager.GetUserAsync(_accessor.HttpContext.User);

        var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == user.ProjectId, cancellationToken);

        if (project == null)
        {
            throw new NotFoundException($"The user with the id:{user.Id} doesn't have a project");
        }


        return _mapper.Map(project);
    }
}