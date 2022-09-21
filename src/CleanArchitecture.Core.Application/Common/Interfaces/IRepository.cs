using CleanArchitecture.Core.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Core.Application.Common.Interfaces;

public interface IRepository : IDisposable
{
    Task Add<T>(T entity) where T : BaseEntity;

    void Update<T>(T entity) where T : BaseEntity;

    IEnumerable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

    IEnumerable<T> GetAll<T>() where T : BaseEntity;

    Task<T> GetSingle<T>(string id) where T : BaseEntity;

    Task<T> First<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

    Task Delete<T>(string id) where T : BaseEntity;

    Task SaveChanges();
}
