using MediatR;

namespace Application.Project.Commands.DeleteProject;

public record DeleteProjectCommand(Guid ProjectId) : IRequest;