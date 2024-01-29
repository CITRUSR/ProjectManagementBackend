using FluentValidation;

namespace Application.Auth.User.Queries.LoginUser;

public class LoginUserValidator : AbstractValidator<LoginUserQuery>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Login).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}