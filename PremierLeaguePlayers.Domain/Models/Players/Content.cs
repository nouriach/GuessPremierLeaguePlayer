using System.Text.Json.Serialization;

namespace PremierLeaguePlayers.Domain.Models.Players;

public class Content
{
    [JsonPropertyName("owner")]
    public Owner Owner { get; set; }
    
    [JsonPropertyName("rank")]
    public int Rank { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("value")]
    public decimal Value { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
}