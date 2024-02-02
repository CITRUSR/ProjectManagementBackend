using Application.Common.Exceptions;
using Domain;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Project.Queries.GetProjectByUser;

public class GetProjectByUserQueryHandler(
    AppDbContext dbContext,
    UserManager<AppUser> userManager,
    IHttpContextAccessor accessor)
    : IRequestHandler<GetProjectByUserQuery, ProjectViewModel>
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly IHttpContextAccessor _accessor = accessor;

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

        return new ProjectViewModel
        {
            Id = project.Id,
            DateStart = project.DateStart,
            DateEnd = project.DateEnd,
            Title = project.Title,
            OwnerId = project.OwnerId,
        };
    }
}