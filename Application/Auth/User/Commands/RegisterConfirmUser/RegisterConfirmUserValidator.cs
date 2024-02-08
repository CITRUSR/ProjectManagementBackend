using FluentValidation;

namespace Application.Auth.User.Commands.RegisterConfirmUser;

public class RegisterConfirmUserValidator : AbstractValidator<RegisterConfirmUserCommand>
{
    public RegisterConfirmUserValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}