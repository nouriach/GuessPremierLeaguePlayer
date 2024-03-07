using System.Text.Json.Serialization;

namespace PremierLeaguePlayers.Domain.Models.Players;

public class Root
{
    [JsonPropertyName("entity")]
    public string Entity { get; set; }

    [JsonPropertyName("stats")]
    public Stats Stats { get; set; }
}