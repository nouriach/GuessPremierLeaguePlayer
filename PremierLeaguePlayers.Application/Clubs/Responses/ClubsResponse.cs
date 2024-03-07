using PremierLeaguePlayers.Domain.Entities;

namespace PremierLeaguePlayers.Application.Clubs.Responses;

public class ClubsResponse
{
    public ClubsResponse()
    {
        Clubs = new List<ClubResponse>();
    }
    public List<ClubResponse> Clubs { get; set; }
}