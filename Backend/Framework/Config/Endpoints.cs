namespace ApiTemplate.Config;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Presentation.Interfaces;

/// <summary>Registers all endpoints from the assembly</summary>
public static class Endpoints
{
    /// <summary>Maps default health check endpoints for the application.</summary>
    /// <param name="app">The <see cref="WebApplication" /> instance to configure.</param>
    /// <returns>The configured <see cref="WebApplication" /> instance.</returns>
    /// <remarks>
    ///     - Maps a readiness endpoint (`/health`) that ensures all health checks pass.
    ///     - Maps a liveness endpoint (`/alive`) that ensures only health checks tagged with "live" pass.
    ///     - Applies caching and request timeout policies for health checks.
    /// </remarks>
    /// <seealso href="https://learn.microsoft.com/dotnet/aspire/fundamentals/health-checks" />
    public static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        var healthChecks = app.MapGroup("");
        healthChecks
            .CacheOutput(HealthChecks.HealthChecksPolicyName)
            .WithRequestTimeout(HealthChecks.HealthChecksPolicyName);

        // All health checks must pass for app to be considered ready to accept traffic after starting
        healthChecks.MapHealthChecks(HealthChecks.HealthEndpointPath);

        // Only health checks tagged with the "live" tag must pass for app to be considered alive
        healthChecks.MapHealthChecks(
            HealthChecks.AlivenessEndpointPath,
            new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains(HealthChecks.AlivenessTag)
            });

        return app;
    }

    /// <summary>Scans the assembly for classes implementing <see cref="IEndpoints" /> and registers them at the app.</summary>
    /// <param name="app">The web app to register the endpoints at</param>
    public static IApplicationBuilder RegisterEndpointsFromAssembly(this IApplicationBuilder app)
    {
        var endpoints = typeof(IEndpoints).Assembly.DefinedTypes
            .Where(x => x.GetInterface(nameof(IEndpoints), false) is not null && x.IsClass);

        foreach (var endpoint in endpoints)
        {
            var instance = Activator.CreateInstance(endpoint);
            var methodInfo = endpoint.GetMethod(nameof(IEndpoints.MapEndpoints));
            methodInfo!.Invoke(instance, [app]);
        }

        return app;
    }
}