using MediatR;

namespace Application.Project.Queries.GetProjectByUser;

public record GetProjectByUserQuery(Guid UserId) : IRequest<ProjectViewModel>;