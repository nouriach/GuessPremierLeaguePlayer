using System.Text.Json.Serialization;

namespace PremierLeaguePlayers.Domain.Models.Clubs;

public class Club
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("shortName")]
    public string ShortName { get; set; }
    [JsonPropertyName("abbr")]
    public string Abbreviation { get; set; }
    [JsonPropertyName("id")]
    public double Id { get; set; }
}