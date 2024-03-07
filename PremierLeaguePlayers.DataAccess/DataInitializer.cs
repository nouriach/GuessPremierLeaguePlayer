using System.Text.Json;
using HtmlAgilityPack;
using PremierLeaguePlayers.Domain.Entities;
using PremierLeaguePlayers.Domain.Models.Clubs;
using PremierLeaguePlayers.Domain.Models.Players;
using Club = PremierLeaguePlayers.Domain.Entities.Club;

namespace PremierLeaguePlayers.DataAccess;

public class DataInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        context.Database.EnsureCreated();

        Console.WriteLine("---> Checking if database has any Player Data");
        if (!context.Players.Any())
        {
            Console.WriteLine("---> Loading data into Player database");
            var players = new List<Player>();
            var deserializedPlayers = await DeserializePlayerData();
            foreach (var player in deserializedPlayers.Stats.Content)
            {
                players.Add( new Player()
                {
                    Position = player.Owner.Info.Position,
                    PositionInfo = player.Owner.Info.PositionInfo,
                    Country = player.Owner.NationalTeam.Country,
                    Nationality = player.Owner.NationalTeam.Demonym,
                    BirthYear = player.Owner.Birth.Date.Label,
                    FirstName = player.Owner.Name.First,
                    LastName = player.Owner.Name.Last,
                    Rank = player.Rank,
                    IsActive = player.Owner.Active,
                    ReferenceId = (int)Math.Round(player.Owner.Id, 0)
                });
            }

            await context.Players.AddRangeAsync(players);
            await context.SaveChangesAsync();
        }

        Console.WriteLine("---> Checking if database has any Club Data");
        if (!context.Clubs.Any())
        {
            Console.WriteLine("---> Loading data into Club database");
            var clubs = new List<Club>();
            var deserializedClubs = await DeserializeClubData();
            foreach (var deserializedContent in deserializedClubs.Content)
            {
                clubs.Add(new Club()
                {
                    Name = deserializedContent.Club.Name.Trim(),
                    ShortName = deserializedContent.Club.ShortName.Trim(),
                    AbbreviatedName = deserializedContent.Club.Abbreviation.Trim()
                });
            }
            await context.Clubs.AddRangeAsync(clubs);
            await context.SaveChangesAsync();
        }

        if (!context.PlayerClubs.Any())
        {
            var playerClubs = new List<PlayerClub>();
            var players = context.Players.Select(x => new
            {
                Id = x.Id,
                ReferenceId = x.ReferenceId
            }).ToList();

            foreach (var player in players)
            {
                Console.WriteLine($"Webscraping for {player.ReferenceId}");

                var clubsElement = GetClubsByPlayerReferenceId(player.ReferenceId);
                
                foreach (var club in clubsElement)
                {
                    var clubName = club.InnerText
                        .Replace(" (Loan)", "")
                        .Replace("&", "and")
                        .Replace("U21", "")
                        .Trim();
                    Console.WriteLine($"Attempting to add {clubName} for {player.ReferenceId}");

                    if (context.Clubs.Any(x => x.Name == clubName))
                    {
                        var clubToAddId = context.Clubs.FirstOrDefault(c => c.Name == clubName).Id;
                        playerClubs.Add(new PlayerClub { PlayerId = player.Id, ClubId = clubToAddId });
                    }
                }
            }
            context.PlayerClubs.AddRange(playerClubs);
            context.SaveChanges();
        }
    }

    private static IEnumerable<HtmlNode> GetClubsByPlayerReferenceId(int referenceId)
    {
        var url = $"https://www.premierleague.com/players/{referenceId}/player/overview";
        var httpClient = new HttpClient();
        var html = httpClient.GetStringAsync(url).Result;
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);

        var clubsElement = htmlDocument.DocumentNode
            .SelectNodes("//span[@class='player-club-history__team-name player-club-history__team-name--long']")
            .Elements()
            .DistinctBy(x => x.InnerText)
            .Reverse();

        return clubsElement;
    }

    private static async Task<RootObject> DeserializeClubData()
    {
        RootObject deserializedClubs;
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clubs.json");
        Console.WriteLine($"---> Generated file path: {filePath}");
        
        using (StreamReader reader = new StreamReader($"{filePath}"))
        {
            var json = await reader.ReadToEndAsync();
            deserializedClubs = JsonSerializer.Deserialize<RootObject>(json);
        }

        return deserializedClubs;
    }
    private static async Task<Root> DeserializePlayerData()
    {
        Root deserializedPlayers;
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "players.json");
        Console.WriteLine($"---> Generated file path: {filePath}");
        
        string[] fileEntries = Directory.GetFiles("/app");
        foreach (var fileName in fileEntries)
            Console.WriteLine(fileName);
            
        using (StreamReader reader = new StreamReader($"{filePath}"))
        { 
            var json = await reader.ReadToEndAsync();
            deserializedPlayers = JsonSerializer.Deserialize<Root>(json);
        }

        return deserializedPlayers;
    }
}