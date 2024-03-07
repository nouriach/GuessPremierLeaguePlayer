using MediatR;
using PremierLeaguePlayers.Domain.Entities;

namespace PremierLeaguePlayers.Application.Players.Queries;

public class GetAllPlayersRequest : IRequest<ICollection<Player>>
{
    
}