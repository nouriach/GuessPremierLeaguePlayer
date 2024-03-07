using System.Text.Json.Serialization;

namespace PremierLeaguePlayers.Domain.Models.Clubs;

public class Content
{
    [JsonPropertyName("club")]
    public Club Club { get; set; }
}