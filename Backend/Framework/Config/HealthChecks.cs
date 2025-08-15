namespace ApiTemplate.Config;

using Microsoft.Extensions.Diagnostics.HealthChecks;

/// <summary>Provides constants and extension methods for configuring health checks in a web application.</summary>
/// <seealso href="https://learn.microsoft.com/dotnet/aspire/fundamentals/health-checks" />
public static class HealthChecks
{
    /// <summary>Path for the liveness endpoint.</summary>
    public const string AlivenessEndpointPath = "/alive";

    /// <summary>Tag used for liveness checks.</summary>
    public const string AlivenessTag = "live";

    /// <summary>Policy name for health checks.</summary>
    public const string HealthChecksPolicyName = "HealthChecks";

    /// <summary>Path for the readiness endpoint.</summary>
    public const string HealthEndpointPath = "/health";

    /// <summary>Adds default health checks to the host application builder.</summary>
    public static TBuilder AddDefaultHealthChecks<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        // add timeout policy for health checks
        builder.Services.AddRequestTimeouts(static timeouts =>
            timeouts.AddPolicy(HealthChecksPolicyName, TimeSpan.FromSeconds(5)));

        // add output caching policy for health checks
        builder.Services.AddOutputCache(static caching =>
            caching.AddPolicy(HealthChecksPolicyName, static policy => policy.Expire(TimeSpan.FromSeconds(10))));

        // Add a default liveness check to ensure app is responsive
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), [AlivenessTag]);

        return builder;
    }
}