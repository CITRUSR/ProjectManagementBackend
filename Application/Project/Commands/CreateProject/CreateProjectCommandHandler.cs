﻿using Domain.Enum;
using Infrastructure;
using MediatR;
using Serilog;

namespace Application.Project.Commands;

public class CreateProjectCommandHandler(IAppDbContext dbContext) : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IAppDbContext _dbContext = dbContext;

    public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        Domain.Project project = new Domain.Project
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            OwnerId = request.OwnerId,
            Status = WorkStatus.Created,
            DateStart = request.DateStart,
            DateEnd = request.DateEnd,
        };

        await _dbContext.Projects.AddAsync(project, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        Log.Information($"The new project with id:{project.Id} is created");

        return project.Id;
    }
}