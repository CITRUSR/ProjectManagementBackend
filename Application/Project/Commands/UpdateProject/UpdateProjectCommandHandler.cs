using Application.Common.Exceptions;
using Application.Common.Mappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Application.Project.Commands.UpdateProject;

public class UpdateProjectCommandHandler(IAppDbContext dbContext, ProjectMapper mapper)
    : IRequestHandler<UpdateProjectCommand, ProjectViewModel>
{
    private readonly IAppDbContext _dbContext = dbContext;
    private readonly ProjectMapper _mapper = mapper;

    public async Task<ProjectViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId, cancellationToken);

        if (project == null)
        {
            throw new NotFoundException($"The project with id:{request.ProjectId} is not found");
        }

        var oldProject = project;

        project.DateStart = request.DateStart;
        project.DateEnd = request.DateEnd;
        project.Title = request.Title;
        project.OwnerId = request.OwnerId;
        project.Status = request.Status;

        await _dbContext.SaveChangesAsync(cancellationToken);

        Log.Information($"The project with id:{request.ProjectId} is updated" + "{@OldProject} to {@NewProject}",
            oldProject, project);

        return _mapper.Map(project);
    }
}