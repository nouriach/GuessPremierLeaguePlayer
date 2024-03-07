using PremierLeaguePlayers.Domain.Entities;

namespace PremierLeaguePlayers.Application.Abstractions;

public interface IPlayerRepository
{
    Task<ICollection<Player>> GetAllPlayers();
    Task<Player> GetPlayerById(int id);
    Task<Player> GetRandomPlayer();
    Task<IEnumerable<Club>> GetClubsByPlayerId(int id);
}