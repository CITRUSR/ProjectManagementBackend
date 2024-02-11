using System.Data;
using FluentValidation;

namespace Application.Auth.User.Commands.RegisterUser;

public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Login).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).NotEmpty();
    }
}