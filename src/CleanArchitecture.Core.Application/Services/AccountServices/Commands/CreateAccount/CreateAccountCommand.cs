using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Enums;
using CleanArchitecture.Core.Application.Common.Interfaces;
using MediatR;
using FluentValidation;

namespace CleanArchitecture.Core.Application.Services.AccountServices.Commands.CreateAccount;

public record CreateAccountCommand : IRequest<Account>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? GitHubUsername { get; set; }
    public AccountType Type { get; set; }
}

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Account>
{
    private readonly IGitHubServices _githubServices;
    private readonly IRepositoryFactory _repositoryFactory;

    public CreateAccountCommandHandler(
        IGitHubServices githubServices,
        IRepositoryFactory repositoryFactory)
    {
        _githubServices = githubServices;
        _repositoryFactory = repositoryFactory;
    }


    public async Task<Account> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateAccountCommandValidator(_githubServices);
        validator.ValidateAndThrow(request);

        var account = new Account
        {
            Name = request.Name,
            Email = request.Email,
            GitHubUsername = request.GitHubUsername,
            Type = request.Type
        };

        using (var repository = _repositoryFactory.Create())
        {
            await repository.Add(account);
            await repository.SaveChanges();
            return account;
        };
    }
}
