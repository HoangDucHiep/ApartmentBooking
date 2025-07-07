using FluentValidation;

namespace Bookify.Application.Users.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{

    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(100);
    }

}