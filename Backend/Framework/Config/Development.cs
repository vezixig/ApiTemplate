namespace ApiTemplate.Config;

using Scalar.AspNetCore;

/// <summary>Provides extension methods for configuring development-specific features in the application builder.</summary>
public static class Development
{
    /// <summary>Configures development-specific features for the web application.</summary>
    /// <remarks>Features are only enabled in the development environment.</remarks>
    public static WebApplication ConfigureDevelopment(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return app;

        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
            options
                .WithTitle("ApiTemplate API Reference")
                .WithTheme(ScalarTheme.BluePlanet)
                .WithDefaultHttpClient(ScalarTarget.JavaScript, ScalarClient.Fetch);
        });

        return app;
    }
}