namespace ApiTemplate.Config;

using global::OpenTelemetry;
using global::OpenTelemetry.Metrics;
using global::OpenTelemetry.Trace;

/// <summary>OpenTelemetry configuration for logging, metrics, and tracing.</summary>
/// <seealso href="https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/telemetry" />
public static class OpenTelemetry
{
    /// <summary>
    ///     Configures OpenTelemetry for logging, metrics, and tracing.
    ///     - Adds OpenTelemetry logging with formatted messages and scopes.
    ///     - Adds metrics instrumentation for ASP.NET Core, HTTP client, runtime, and Prometheus exporter.
    ///     - Adds tracing instrumentation for ASP.NET Core, HTTP client
    ///     - Excludes health check endpoints from tracing.
    ///     - Adds OpenTelemetry exporters based on configuration.
    /// </summary>
    public static TBuilder ConfigureOpenTelemetry<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        builder.Logging.AddOpenTelemetry(logging =>
        {
            logging.IncludeFormattedMessage = true;
            logging.IncludeScopes = true;
        });

        builder.Services.AddOpenTelemetry()
            .WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddRuntimeInstrumentation();
            })
            .WithTracing(tracing =>
            {
                // Exclude health check requests from tracing
                tracing.AddSource(builder.Environment.ApplicationName)
                    .AddAspNetCoreInstrumentation(o =>
                        o.Filter = context =>
                            !context.Request.Path.StartsWithSegments(HealthChecks.HealthEndpointPath)
                            && !context.Request.Path.StartsWithSegments(HealthChecks.AlivenessEndpointPath)
                    )
                    .AddHttpClientInstrumentation();
            });

        builder = builder.AddOpenTelemetryExporters();
        return builder;
    }

    private static TBuilder AddOpenTelemetryExporters<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        var useOtlpExporter = !string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]);
        if (useOtlpExporter) builder.Services.AddOpenTelemetry().UseOtlpExporter();
        return builder;
    }
}