using System.Text.Json.Serialization;

namespace PremierLeaguePlayers.Domain.Models.Players;

public class Date
{
    [JsonPropertyName("millis")]
    public decimal Millis { get; set; }
    
    [JsonPropertyName("label")]
    public string Label { get; set; }
}