using System.Text.Json.Serialization;

namespace PremierLeaguePlayers.Domain.Models.Players;

public class Owner
{
    [JsonPropertyName("playerId")]
    public decimal PlayerId { get; set; }
    
    [JsonPropertyName("info")]
    public Info Info { get; set; }
    
    [JsonPropertyName("nationalTeam")]
    public NationalTeam NationalTeam { get; set; }
    
    [JsonPropertyName("currentTeam")]
    public CurrentTeam CurrentTeam { get; set; }
    
    [JsonPropertyName("active")]
    public bool Active { get; set; }
    
    [JsonPropertyName("birth")]
    public Birth Birth { get; set; }
    
    [JsonPropertyName("age")]
    public string Age { get; set; }
    
    [JsonPropertyName("name")]
    public Name Name { get; set; }
    
    [JsonPropertyName("id")]
    public decimal Id { get; set; }
}