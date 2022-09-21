using CleanArchitecture.Core.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure.Services.GitHub;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Polly.Contrib.WaitAndRetry;
using Polly;
using Refit;

namespace CleanArchitecture.Infrastructure.Services;

public static class ConfigureServices
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        services.AddRefitClient<IGitHubClient>()
            .ConfigureHttpClient(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.github.com/");

                // using Microsoft.Net.Http.Headers;
                // The GitHub API requires two headers.
                httpClient.DefaultRequestHeaders.Add(
                    HeaderNames.Accept, "application/vnd.github.v3+json");
                httpClient.DefaultRequestHeaders.Add(
                    HeaderNames.UserAgent, $"CleanArchitecture-{Environment.MachineName}");
            })
            .AddTransientHttpErrorPolicy(policyBuilder =>
                policyBuilder.WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5)));

            //.AddPolicyHandler(
            //    Policy<HttpResponseMessage>
            //    .Handle<HttpRequestException>()
            //    .OrResult(x => x.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
            //    .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5)));

        services.AddTransient<IGitHubServices, GitHubServices>();

        return services;
    }
}