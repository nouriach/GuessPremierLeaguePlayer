using System.Text.Json.Serialization;

namespace PremierLeaguePlayers.Domain.Models.Players;

public class Info
{
    [JsonPropertyName("position")]
    public string Position { get; set; }

    [JsonPropertyName("shirtNum")]
    public decimal ShirtNum { get; set; }

    [JsonPropertyName("positionInfo")]
    public string PositionInfo { get; set; }

    [JsonPropertyName("loan")]
    public bool Loan { get; set; }
}