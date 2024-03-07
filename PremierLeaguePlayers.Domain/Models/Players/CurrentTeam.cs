using System.Text.Json.Serialization;
using PremierLeaguePlayers.Domain.Models.Clubs;

namespace PremierLeaguePlayers.Domain.Models.Players;

public class CurrentTeam
{    
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("club")]
    public Club Club { get; set; }

    [JsonPropertyName("teamType")]
    public string TeamType { get; set; }

    [JsonPropertyName("shortName")]
    public string ShortName { get; set; }

    [JsonPropertyName("id")]
    public decimal Id { get; set; }
}