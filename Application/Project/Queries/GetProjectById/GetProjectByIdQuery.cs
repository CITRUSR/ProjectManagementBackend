using MediatR;

namespace Application.Project.Queries.GetProjectById;

public record GetProjectByIdQuery(Guid ProjectId) : IRequest<ProjectViewModel>;