using MediatR;
using Microsoft.EntityFrameworkCore;
using PremierLeaguePlayers.Application.Abstractions;
using PremierLeaguePlayers.Application.Players.Queries;
using PremierLeaguePlayers.DataAccess;
using PremierLeaguePlayers.DataAccess.Repositories;
using PremierLeaguePlayers.MinimalAPI.Abstractions;

namespace PremierLeaguePlayers.MinimalAPI.Extensions;

public static class MinimalApiExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var cs = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<AppDbContext>(
            opt => opt.UseSqlServer(cs));

        var dataSource = builder.Configuration["DataSource"];
        if (dataSource == "Json")
        {
            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
        }
        else
        {
            builder.Services.AddScoped<IPlayerRepository, EfPlayerRepository>();
        }

        builder.Services.AddMediatR(typeof(GetAllPlayersRequest).Assembly);
        builder.Services.AddMediatR(typeof(GetPlayerByIdRequest).Assembly);
        builder.Services.AddMediatR(typeof(GetRandomPlayerRequest).Assembly);
    }

    public static void RegisterEndpointDefinitions(this WebApplication app)
    {
        var endpointDefinitions = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition)) 
                && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();

        foreach (var endpointDef in endpointDefinitions)
        { 
            endpointDef.RegisterEndpoints(app);   
        }
    }
}