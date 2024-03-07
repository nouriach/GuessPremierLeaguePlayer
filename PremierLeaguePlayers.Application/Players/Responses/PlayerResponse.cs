using PremierLeaguePlayers.Application.Clubs.Responses;

namespace PremierLeaguePlayers.Application.Players.Responses;

public class PlayerResponse
{
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
    public ClubsResponse Clubs { get; set; }
}