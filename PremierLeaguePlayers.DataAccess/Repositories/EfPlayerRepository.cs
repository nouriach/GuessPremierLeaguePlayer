using Microsoft.EntityFrameworkCore;
using PremierLeaguePlayers.Application.Abstractions;
using PremierLeaguePlayers.Domain.Entities;

namespace PremierLeaguePlayers.DataAccess.Repositories;

public class EfPlayerRepository : IPlayerRepository
{
    private readonly AppDbContext _context;

    public EfPlayerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Player>> GetAllPlayers()
    {
        return await _context.Players.ToListAsync();
    }

    public async Task<Player> GetPlayerById(int id)
    {
        var player = await _context.Players
            .Include(pl => pl.PlayerClubs)
            .FirstOrDefaultAsync(x => x.Id == id);
;
        if (player == null)
            return null;

        return player;
    }

    public async Task<Player> GetRandomPlayer()
    {
        var rand = new Random();
        var indexOne = _context.Players.OrderBy(x => x.Id).First().Id;
        var indexTwo = _context.Players.OrderBy(x => x.Id).Last().Id;
        var randomIndex = rand.Next(indexOne, indexTwo);

        return await GetPlayerById(randomIndex);
    }

    public async Task<IEnumerable<Club>> GetClubsByPlayerId(int id)
    {
        var clubs = await _context.PlayerClubs
            .Where(x => x.PlayerId == id)
            .Select(c => c.Club)
            .ToListAsync();

        if (clubs.Any())
        {
            return clubs;
        }

        return null;
    }
    
}