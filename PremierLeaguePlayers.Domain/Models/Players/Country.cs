using System.Text.Json.Serialization;

namespace PremierLeaguePlayers.Domain.Models.Players;

public class Country
{
    [JsonPropertyName("isoCode")]
    public string IsoCode { get; set; }
    
    [JsonPropertyName("country")]
    public string Name { get; set; }
    
    [JsonPropertyName("demonym")]
    public string Demonym { get; set; }
}