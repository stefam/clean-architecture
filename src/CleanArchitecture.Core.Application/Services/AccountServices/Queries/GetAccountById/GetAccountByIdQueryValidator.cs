using FluentValidation;

namespace CleanArchitecture.Core.Application.Services.AccountServices.Queries.GetAccountById;

public class GetAccountByIdQueryValidator : AbstractValidator<GetAccountByIdQuery>
{
    public GetAccountByIdQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
    }
}
