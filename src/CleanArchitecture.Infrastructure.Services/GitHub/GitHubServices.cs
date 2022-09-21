﻿using CleanArchitecture.Core.Application.Common.Interfaces;
using CleanArchitecture.Core.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Services.GitHub;

public class GitHubServices : IGitHubServices
{
    private readonly IGitHubClient _gitHubClient;

    public GitHubServices(IGitHubClient gitHubClient) =>
        _gitHubClient = gitHubClient;

    public async Task<GitHubUser> GetProfile(string userName)
    {
        var user = await _gitHubClient.GetUser(userName);

        return new GitHubUser
        {
            Id = user.id,
            Login = user.login
        };
    }
}