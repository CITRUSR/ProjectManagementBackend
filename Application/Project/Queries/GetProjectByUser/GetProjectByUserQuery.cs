using MediatR;

namespace Application.Project.Queries.GetProjectByUser;

public record GetProjectByUserQuery() : IRequest<ProjectViewModel>;