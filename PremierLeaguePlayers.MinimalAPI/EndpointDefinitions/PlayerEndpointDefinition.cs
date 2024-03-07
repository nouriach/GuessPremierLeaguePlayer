using MediatR;
using PremierLeaguePlayers.Application.Players.Queries;
using PremierLeaguePlayers.MinimalAPI.Abstractions;

namespace PremierLeaguePlayers.MinimalAPI.EndpointDefinitions;

public class PlayerEndpointDefinition : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var players = app.MapGroup("/api/v1/players");

        players.MapGet("/", GetAllPlayers);
        players.MapGet("/{id}", GetPlayerById);
        players.MapGet("/random", GetRandomPlayer);
    }

    private static async Task<IResult> GetPlayerById(IMediator mediator, int id)
    {
        var player = await mediator.Send(new GetPlayerByIdRequest() { Id = id });
        return TypedResults.Ok(player);
    }

    private static async Task<IResult> GetAllPlayers(IMediator mediator)
    {
        var players = await mediator.Send(new GetAllPlayersRequest());
        return TypedResults.Ok(players);
    }
    
    private static async Task<IResult> GetRandomPlayer(IMediator mediator)
    {
        var player = await mediator.Send(new GetRandomPlayerRequest());
        return TypedResults.Ok(player);
    }
}