using CleanArchitecture.Core.Application.Common.Interfaces;

namespace CleanArchitecture.Infrastructure.DataAccess;

public class RepositoryFactory : IRepositoryFactory
{
    public IRepository CreateRepository()
    {
        throw new NotImplementedException();
    }
}
