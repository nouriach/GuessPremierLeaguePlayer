using System.Text.Json.Serialization;

namespace PremierLeaguePlayers.Domain.Models.Players;

public class Name
{
    [JsonPropertyName("display")]
    public string Display { get; set; }
    
    [JsonPropertyName("first")]
    public string First { get; set; }
    
    [JsonPropertyName("last")]
    public string Last { get; set; }
}