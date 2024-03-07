using System.Text.Json.Serialization;

namespace PremierLeaguePlayers.Domain.Models.Players;

public class NationalTeam
{
    [JsonPropertyName("isoCode")]    
    public string IsoCode { get; set; }
    
    [JsonPropertyName("country")]    
    public string Country { get; set; }
    
    [JsonPropertyName("demonym")]    
    public string Demonym { get; set; }
}