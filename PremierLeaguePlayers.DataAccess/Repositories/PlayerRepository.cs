using System.Text.Json;
using PremierLeaguePlayers.Application.Abstractions;
using PremierLeaguePlayers.Domain.Entities;
using PremierLeaguePlayers.Domain.Models;
using PremierLeaguePlayers.Domain.Models.Players;

namespace PremierLeaguePlayers.DataAccess.Repositories;

public class PlayerRepository : IPlayerRepository
{
    public async Task<ICollection<Player>> GetAllPlayers()
    {
        var players = new List<Player>();
        var deserializedPlayers = await DeserializePlayerData();
        var index = 0;
        foreach (var player in deserializedPlayers.Stats.Content)
        {
            players.Add( new Player()
            {
                Id = index,
                Position = player.Owner.Info.Position,
                PositionInfo = player.Owner.Info.PositionInfo,
                Country = player.Owner.NationalTeam.Country,
                Nationality = player.Owner.NationalTeam.Demonym,
                BirthYear = player.Owner.Birth.Date.Label,
                FirstName = player.Owner.Name.First,
                LastName = player.Owner.Name.Last,
                Rank = player.Rank,
                IsActive = player.Owner.Active,
                ReferenceId = (int)Math.Round(player.Owner.Id, 0)
            });
            index = index++;
        }
        return players;
    }


    public async Task<Player> GetPlayerById(int id)
    {
        var players = await GetAllPlayers();
        var player = players.FirstOrDefault(p => p.ReferenceId == id);

        return player;
    }
    
    public async Task<Player> GetRandomPlayer()
    {
        var deserializedPlayers = await DeserializePlayerData();
        var players = deserializedPlayers.Stats.Content;

        // This is currently buggy as there isn't a perfect chronology of Rank.
        // Occassionally there are missing values: see rank #79 for example in players.json
        Random rand = new Random();
        var randomRank = rand.Next(players.First().Rank, players.Last().Rank);
        var randomPlayer = players.FirstOrDefault(p => p.Rank == randomRank);

        if (randomPlayer == null)
            throw new Exception($"No player found. Random Rank: {randomRank}");
        
        return new Player()
        {
            Position = randomPlayer.Owner.Info.Position,
            PositionInfo = randomPlayer.Owner.Info.PositionInfo,
            Country = randomPlayer.Owner.NationalTeam.Country,
            Nationality = randomPlayer.Owner.NationalTeam.Demonym,
            BirthYear = randomPlayer.Owner.Birth.Date.Label,
            FirstName = randomPlayer.Owner.Name.First,
            LastName = randomPlayer.Owner.Name.Last,
            Rank = randomPlayer.Rank,
            IsActive = randomPlayer.Owner.Active,
            ReferenceId = (int)Math.Round(randomPlayer.Owner.Id, 0)
        };
    }

    public Task<IEnumerable<Club>> GetClubsByPlayerId(int id)
    {
        return null;
    }

    private static async Task<Root> DeserializePlayerData()
    {
        Root deserializedPlayers;
        using (StreamReader reader = new
                   StreamReader(
                       "/Users/nathanouriach/RiderProjects/PremierLeaguePlayers/PremierLeaguePlayersPremierLeaguePlayers.DataAccess/players.json"))
        {
            var json = await reader.ReadToEndAsync();
            deserializedPlayers = JsonSerializer.Deserialize<Root>(json);
        }

        return deserializedPlayers;
    }
}
