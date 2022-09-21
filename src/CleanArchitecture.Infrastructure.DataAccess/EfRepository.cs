using CleanArchitecture.Core.Application.Common.Interfaces;
using CleanArchitecture.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.DataAccess;

public class EfRepository : IRepository
{
    private readonly DbContext _dbContext;

    public EfRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add<T>(T entity) where T : BaseEntity =>
        await _dbContext.AddAsync(entity);

    public void Update<T>(T entity) where T : BaseEntity =>
        _dbContext.Update(entity);

    public IEnumerable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity =>
        _dbContext.Set<T>()
        .Where(predicate);

    public IEnumerable<T> GetAll<T>() where T : BaseEntity =>
        _dbContext.Set<T>();

    public async Task<T?> GetSingle<T>(string id) where T : BaseEntity =>
        await _dbContext.Set<T>()
        .FindAsync(id);

    public async Task<T?> First<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity =>
        await _dbContext.Set<T>()
        .FirstOrDefaultAsync(predicate);

    public async Task Delete<T>(string id) where T : BaseEntity {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        _dbContext.Remove(entity!);
    }

    public async Task SaveChanges() =>
        await _dbContext.SaveChangesAsync();

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
