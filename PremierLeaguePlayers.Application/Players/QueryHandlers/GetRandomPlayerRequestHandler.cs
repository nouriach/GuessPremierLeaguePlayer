using MediatR;
using PremierLeaguePlayers.Application.Abstractions;
using PremierLeaguePlayers.Application.Clubs.Responses;
using PremierLeaguePlayers.Application.Players.Queries;
using PremierLeaguePlayers.Application.Players.Responses;

namespace PremierLeaguePlayers.Application.Players.QueryHandlers;

public class GetRandomPlayerRequestHandler : IRequestHandler<GetRandomPlayerRequest, PlayerResponse>
{
    private readonly IPlayerRepository _playerRepository;

    public GetRandomPlayerRequestHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }
    public async Task<PlayerResponse> Handle(GetRandomPlayerRequest request, CancellationToken cancellationToken)
    {
        var player = await _playerRepository.GetRandomPlayer();
        var playerClubs = await _playerRepository.GetClubsByPlayerId(player.Id);
        
        var clubsResponse = new ClubsResponse();

        foreach (var playerClub in playerClubs.Distinct())
        {
            clubsResponse.Clubs.Add(new ClubResponse()
            {
                Name = playerClub.Name,
                ShortName = playerClub.ShortName,
                AbbreviatedName = playerClub.AbbreviatedName
            });
        }

        return new PlayerResponse()
        {
            Position = player.Position,
            PositionInfo = player.PositionInfo,
            Country = player.Country,
            Nationality = player.Nationality,
            BirthYear = player.BirthYear,
            FirstName = player.FirstName,
            LastName = player.LastName,
            Rank = player.Rank,
            IsActive = player.IsActive,
            ReferenceId = player.ReferenceId,
            Clubs = clubsResponse
        };
    }
}