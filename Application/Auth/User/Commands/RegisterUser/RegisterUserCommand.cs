using MediatR;

namespace Application.Auth.User.Commands.RegisterUser;

public record RegisterUserCommand(string Login, string Password, string ConfirmPassword) : IRequest;