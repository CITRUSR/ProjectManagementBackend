using MediatR;

namespace Application.Project.Queries.GetAllProjects;

public record GetAllProjectsQuery() : IRequest<List<ProjectViewModel>>;