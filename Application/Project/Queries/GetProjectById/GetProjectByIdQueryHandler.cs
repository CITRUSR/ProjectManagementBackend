﻿using Application.Common.Exceptions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Project.Queries.GetProjectById;

public class GetProjectByIdQueryHandler(AppDbContext dbContext)
    : IRequestHandler<GetProjectByIdQuery, ProjectViewModel>
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<ProjectViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Project project =
            await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId, cancellationToken);

        if (project == null)
        {
            throw new NotFoundException($"Project with id: {request.ProjectId} not found");
        }

        ProjectViewModel projectVM = new ProjectViewModel
        {
            Id = project.Id,
            Title = project.Title,
            DateEnd = project.DateEnd,
            DateStart = project.DateStart,
        };

        return projectVM;
    }
}