using MediatR;
using PremierLeaguePlayers.Application.Abstractions;
using PremierLeaguePlayers.Application.Players.Queries;
using PremierLeaguePlayers.Domain.Entities;

namespace PremierLeaguePlayers.Application.Players.QueryHandlers;

public class GetAllPlayersRequestHandler : IRequestHandler<GetAllPlayersRequest, ICollection<Player>>
{
    private readonly IPlayerRepository _playerRepository;

    public GetAllPlayersRequestHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<ICollection<Player>> Handle(GetAllPlayersRequest request, CancellationToken cancellationToken)
    {
        return await _playerRepository.GetAllPlayers();
    }
}