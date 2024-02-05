using Application.Common.Exceptions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Application.Project.Commands.DeleteProject;

public class DeleteProjectCommandHandler(IAppDbContext dbContext) : IRequestHandler<DeleteProjectCommand>
{
    private readonly IAppDbContext _dbContext = dbContext;

    public async System.Threading.Tasks.Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId, cancellationToken);

        if (project == null)
        {
            throw new NotFoundException($"The project with id:{request.ProjectId} is not found");
        }

        _dbContext.Projects.Remove(project);

        Log.Information($"The project with id:{request.ProjectId} is deleted");

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}