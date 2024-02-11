using Application.Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.User.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterUserCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async System.Threading.Tasks.Task<Unit> Handle(RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = new AppUser
        {
            UserName = request.Login,
            Position = request.Position,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new IdentityException("Identity error", result.Errors);
        }

        return Unit.Value;
    }
}