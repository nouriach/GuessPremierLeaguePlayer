using System.Text.Json.Serialization;

namespace PremierLeaguePlayers.Domain.Models.Clubs;

public class RootObject
{
    [JsonPropertyName("content")]
    public Content[] Content { get; set; }
}