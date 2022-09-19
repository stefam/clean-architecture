using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Core.Application.Services.AccountServices.Commands.CreateAccount;

public record CreateAccountCommand : IRequest<Account>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public AccountType Type { get; set; }
}

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Account>
{
    public async Task<Account> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        return await Task.Run(() => new Account());
    }
}
