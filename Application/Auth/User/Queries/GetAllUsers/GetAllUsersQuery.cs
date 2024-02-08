using MediatR;

namespace Application.Auth.User.Queries.GetAllUsers;

public record GetAllUsersQuery() : IRequest<List<UserViewModel>>;