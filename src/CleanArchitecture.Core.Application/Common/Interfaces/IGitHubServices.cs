namespace CleanArchitecture.Core.Application.Common.Interfaces;

public interface IGitHubServices
{
    Task<bool> IsValidUser(string username);
}
