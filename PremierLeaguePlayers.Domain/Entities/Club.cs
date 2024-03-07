using System.ComponentModel.DataAnnotations;

namespace PremierLeaguePlayers.Domain.Entities;

public class Club
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string AbbreviatedName { get; set; }
    public ICollection<Player> PlayerClubs { get; set; }
}