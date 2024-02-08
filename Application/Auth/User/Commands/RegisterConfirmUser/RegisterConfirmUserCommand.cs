using Domain.Enum;
using MediatR;

namespace Application.Auth.User.Commands.RegisterConfirmUser;

public record RegisterConfirmUserCommand(string Id, Position Position) : IRequest;