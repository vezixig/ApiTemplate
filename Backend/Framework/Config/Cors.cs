namespace ApiTemplate.Config;

/// <summary>Provides extension methods for configuring CORS in the application builder.</summary>
public static class Cors
{
    /// <summary>Configures CORS policy for the application.</summary>
    /// <param name="builder">The WebApplicationBuilder to configure.</param>
    public static WebApplicationBuilder ConfigureCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("https://localhost:7139")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        return builder;
    }
}