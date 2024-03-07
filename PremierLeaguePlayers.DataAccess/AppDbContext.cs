using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using PremierLeaguePlayers.Domain.Entities;

namespace PremierLeaguePlayers.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
        
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Club> Clubs { get; set; }
    public DbSet<PlayerClub> PlayerClubs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Player>()
        //     .HasMany(x => x.Clubs)
        //     .WithMany(x => x.Players)
        //     .UsingEntity(x => x.ToTable("PlayerClub"));
    }
}