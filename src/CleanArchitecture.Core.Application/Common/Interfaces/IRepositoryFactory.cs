namespace CleanArchitecture.Core.Application.Common.Interfaces;

public interface IRepositoryFactory
{
    IRepository CreateRepository();
}
