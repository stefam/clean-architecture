using CleanArchitecture.Core.Domain.Common;
using CleanArchitecture.Core.Domain.Enums;

namespace CleanArchitecture.Core.Domain.Entities;

public class Account : BaseEntity
{
    public string? Name { get; set; }

    public string? Email { get; set; }

    public AccountType Type { get; set; }
}
