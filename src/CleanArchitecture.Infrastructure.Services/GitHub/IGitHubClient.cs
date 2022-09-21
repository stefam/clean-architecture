using Refit;

namespace CleanArchitecture.Infrastructure.Services.GitHub;

public interface IGitHubClient
{
    [Get("/users/{user}")]
    Task<User> GetUser(string user);
}
