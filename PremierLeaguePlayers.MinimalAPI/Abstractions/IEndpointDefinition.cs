namespace PremierLeaguePlayers.MinimalAPI.Abstractions;

public interface IEndpointDefinition
{
    void RegisterEndpoints(WebApplication app);
}