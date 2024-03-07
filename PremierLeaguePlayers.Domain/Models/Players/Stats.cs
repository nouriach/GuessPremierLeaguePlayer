using System.Text.Json.Serialization;

namespace PremierLeaguePlayers.Domain.Models.Players;

public class Stats
{
    [JsonPropertyName("content")]
    public List<Content> Content { get; set; }
}