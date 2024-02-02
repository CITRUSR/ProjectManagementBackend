using MediatR;

namespace Application.Project.Commands;

public record CreateProjectCommand(string Title, Guid OwnerId, DateTime DateStart, DateTime DateEnd) : IRequest<Guid>;