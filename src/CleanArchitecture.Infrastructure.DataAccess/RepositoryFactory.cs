using CleanArchitecture.Core.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DataAccess;

public class RepositoryFactory : IRepositoryFactory
{
    private readonly DbContext _dbContext;

    public RepositoryFactory(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IRepository Create()
    {
        return new EfRepository(_dbContext);
    }
}
