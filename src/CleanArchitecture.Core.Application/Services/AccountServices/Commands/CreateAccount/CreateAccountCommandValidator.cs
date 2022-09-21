using CleanArchitecture.Core.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Core.Application.Services.AccountServices.Commands.CreateAccount;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator(IGitHubServices githubServices)
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.Email)
            .EmailAddress();

        RuleFor(v => v.GitHubUsername)
            .MustAsync(async (username, cancellation) =>
                await githubServices.IsValidUser(username!))
            .WithMessage("GitHubUsername is not a valid GitHub username.");
    }
}