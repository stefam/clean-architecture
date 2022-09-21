using CleanArchitecture.Core.Application.Common.Interfaces;
using CleanArchitecture.Core.Domain.Entities;
using Refit;
using System.Net;

namespace CleanArchitecture.Infrastructure.Services.GitHub;

public class GitHubServices : IGitHubServices
{
    private readonly IGitHubClient _gitHubClient;

    public GitHubServices(IGitHubClient gitHubClient) =>
        _gitHubClient = gitHubClient;

    public async Task<bool> IsValidUser(string username)
    {
        try
        {
            var user = await GetProfile(username);
            return user is not null;
        }
        catch (ApiException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound)
                return false;

            throw;
        }
    }

    private async Task<GitHubUser> GetProfile(string userName)
    {
        var user = await _gitHubClient.GetUser(userName);

        return new GitHubUser
        {
            Id = user.id,
            Login = user.login
        };
    }
}
