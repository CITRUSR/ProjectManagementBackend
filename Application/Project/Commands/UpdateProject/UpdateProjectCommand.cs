using Domain.Enum;
using MediatR;

namespace Application.Project.Commands.UpdateProject;

public record UpdateProjectCommand(
    Guid ProjectId,
    DateTime DateStart,
    DateTime DateEnd,
    ProjectStatus Status,
    Guid OwnerId,
    string Title) : IRequest<ProjectViewModel>;