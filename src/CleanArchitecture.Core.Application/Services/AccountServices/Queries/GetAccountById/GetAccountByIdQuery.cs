using CleanArchitecture.Core.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Core.Application.Services.AccountServices.Queries.GetAccountById;

public record GetAccountByIdQuery : IRequest<Account>
{
    public Guid Id { get; set; }
}

public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, Account>
{
    public async Task<Account> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.Run(() => new Account());
    }
}
