using MediatR;
using PremierLeaguePlayers.Domain.Entities;

namespace PremierLeaguePlayers.Application.Players.Queries;

public class GetPlayerByIdRequest : IRequest<Player>
{
    public int Id { get; set; }
}