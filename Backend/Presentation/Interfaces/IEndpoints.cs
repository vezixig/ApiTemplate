namespace ApiTemplate.Presentation.Interfaces;

using Microsoft.AspNetCore.Builder;

/// <summary>Defines the contract for mapping endpoints in the application.</summary>
public interface IEndpoints
{
    /// <summary>Maps the endpoints to the application.</summary>
    void MapEndpoints(WebApplication app);
}