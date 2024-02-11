using Domain.Enum;
using MediatR;

namespace Application.Auth.User.Commands.RegisterUser;

public record RegisterUserCommand(string Login, Position Position, string Password, string ConfirmPassword) : IRequest<Unit>;