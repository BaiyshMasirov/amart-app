using FluentValidation;

namespace Amart.Application.MediatR.Accounts.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(v => v.Login)
                .NotEmpty().WithMessage("Login is required");
            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}