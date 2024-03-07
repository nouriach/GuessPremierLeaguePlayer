using System.ComponentModel.DataAnnotations;

namespace PremierLeaguePlayers.Domain.Entities;
public class Player
{
    [Key]
    public int Id { get; set; }
    public string? Position { get; set; }
    public string? PositionInfo { get; set; }
    public string? Country { get; set; }
    public string? Nationality { get; set; }
    public string? BirthYear { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Rank { get; set; }
    public bool IsActive { get; set; }
    public int ReferenceId { get; set; }
    public ICollection<Player> PlayerClubs { get; set; }
}