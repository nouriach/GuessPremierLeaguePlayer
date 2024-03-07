using System.Text.Json.Serialization;

namespace PremierLeaguePlayers.Domain.Models.Players;

public class Birth
{    
    [JsonPropertyName("date")]
    public Date Date { get; set; }
}