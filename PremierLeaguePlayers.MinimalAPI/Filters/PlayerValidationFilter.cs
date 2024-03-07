using PremierLeaguePlayers.Domain.Models;

namespace PremierLeaguePlayers.MinimalAPI.Filters;

public class PlayerValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, 
        EndpointFilterDelegate next)
    {
        Console.WriteLine("Running validation on request...");
        // To add this validation to a specific endpoint append .AddEndpointFilter<Player>()
        return await next(context);
    }
}