using Application.Common.Exceptions;
using Domain;
using Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.User.Commands.RegisterConfirmUser;

public class RegisterConfirmUserCommandHandler(UserManager<AppUser> userManager)
    : IRequestHandler<RegisterConfirmUserCommand>
{
    private readonly UserManager<AppUser> _userManager = userManager;

    public async System.Threading.Tasks.Task Handle(RegisterConfirmUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id);

        if (user == null)
        {
            throw new NotFoundException($"User with id:{request.Id} is not found");
        }

        var result = await (request.Position == Position.ProjectManager
            ? _userManager.AddToRoleAsync(user, "ProjectManager")
            : _userManager.AddToRoleAsync(user, "User"));

        if (!result.Succeeded)
        {
            throw new IdentityException("Identity error", result.Errors);
        }

        user.IsConfirmedProfile = true;
        await _userManager.UpdateAsync(user);
    }
}