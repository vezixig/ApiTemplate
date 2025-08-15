namespace ApiTemplate.Config;

/// <summary>Provides extension methods for configuring HTTP client defaults in the application builder.</summary>
public static class HttpClient
{
    /// <summary>Configures default HTTP client settings.</summary>
    /// <remarks> This method sets up the HTTP client with standard resilience handlers.</remarks>
    public static TBuilder ConfigureHttpClientDefaults<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        builder.Services.ConfigureHttpClientDefaults(http => { http.AddStandardResilienceHandler(); });
        return builder;
    }
}