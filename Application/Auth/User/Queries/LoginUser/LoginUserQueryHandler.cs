using Application.Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace Application.Auth.User.Queries.LoginUser;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly JWTGenerator _jwtGenerator;

    public LoginUserQueryHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, JWTGenerator jwtGenerator)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Login);

        if (user == null)
        {
            throw new NotFoundException("User not found");
        }
        
        var result = await _signInManager.PasswordSignInAsync(user, request.Password,false,false);

        if (!result.Succeeded)
        {
            throw new IdentityException("Login or password is wrong");
        }
        
        Log.Information($"User with name {request.Login} is login");
        
        return await _jwtGenerator.Generate(user);
    }
}