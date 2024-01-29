using MediatR;

namespace Application.Auth.User.Queries.LoginUser;

public record LoginUserQuery(string Login, string Password) : IRequest<string>;
