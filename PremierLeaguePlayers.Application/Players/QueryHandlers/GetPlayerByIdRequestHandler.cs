using MediatR;
using PremierLeaguePlayers.Application.Abstractions;
using PremierLeaguePlayers.Application.Players.Queries;
using PremierLeaguePlayers.Domain.Entities;

namespace PremierLeaguePlayers.Application.Players.QueryHandlers;

public class GetPlayerByIdRequestHandler : IRequestHandler<GetPlayerByIdRequest, Player>
{
    private readonly IPlayerRepository _playerRepository;

    public GetPlayerByIdRequestHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }
    public async Task<Player> Handle(GetPlayerByIdRequest request, CancellationToken cancellationToken)
    {
        // need to include clubs
        return await _playerRepository.GetPlayerById(request.Id);
    }
}