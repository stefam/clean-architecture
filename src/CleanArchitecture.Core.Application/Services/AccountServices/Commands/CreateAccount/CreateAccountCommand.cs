using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Enums;
using MediatR;
using FluentValidation;
using CleanArchitecture.Core.Application.Common.Interfaces;

namespace CleanArchitecture.Core.Application.Services.AccountServices.Commands.CreateAccount;

public record CreateAccountCommand : IRequest<Account>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public AccountType Type { get; set; }
}

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Account>
{
    private readonly IRepositoryFactory _repositoryFactory;

    public CreateAccountCommandHandler(IRepositoryFactory repositoryFactory) =>
        _repositoryFactory = repositoryFactory;

    public async Task<Account> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateAccountCommandValidator();
        validator.ValidateAndThrow(request);

        var account = new Account
        {
            Name = request.Name,
            Email = request.Email
        };

        using (var repository = _repositoryFactory.Create())
        {
            await repository.Add(account);
            await repository.SaveChanges();
            return account;
        };
    }
}
