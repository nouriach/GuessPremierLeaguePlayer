using Microsoft.EntityFrameworkCore;

namespace PremierLeaguePlayers.Domain.Entities;

public class PlayerClub
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int ClubId { get; set; }
    public Player Player { get; set; }
    public Club Club { get; set; }
}