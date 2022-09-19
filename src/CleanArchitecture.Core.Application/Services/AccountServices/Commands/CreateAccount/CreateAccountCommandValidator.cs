using FluentValidation;

namespace CleanArchitecture.Core.Application.Services.AccountServices.Commands.CreateAccount;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.Email)
            .EmailAddress();
    }
}