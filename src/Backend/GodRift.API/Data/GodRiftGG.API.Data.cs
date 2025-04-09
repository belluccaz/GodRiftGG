using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using GodRift.API.Models;
using GodRiftGG.Models;

namespace GodRiftGG.API.Data;

public class GodRiftGGContext : DbContext
{
    public GodRiftGGContext(DbContextOptions<GodRiftGGContext> options) : base(options) { }

    public DbSet<Users> Users => Set<Users>();
    public DbSet<Players> Players => Set<Players>();
    public DbSet<Champions> Champions => Set<Champions>();
    public DbSet<Items> Items => Set<Items>();
    public DbSet<Builds> Builds => Set<Builds>();
    public DbSet<Lanes> Lanes => Set<Lanes>();
    public DbSet<ChampionsOnLane> ChampionsOnLane => Set<ChampionsOnLane>();
    public DbSet<Matches> Matches => Set<Matches>();
    public DbSet<MatchPlayers> MatchPlayers => Set<MatchPlayers>();
    public DbSet<PlayersMatchItems> PlayersMatchItems => Set<PlayersMatchItems>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // USERS
        modelBuilder.Entity<Users>().ToTable("Users");
        modelBuilder.Entity<Users>().HasKey(u => u.UserId);
        modelBuilder.Entity<Users>().Property(u => u.UserId).HasColumnName("UserId");
        modelBuilder.Entity<Users>().Property(u => u.Name);
        modelBuilder.Entity<Users>().Property(u => u.Email);
        modelBuilder.Entity<Users>().Property(u => u.HashPassword);
        modelBuilder.Entity<Users>().Property(u => u.CreatedAt);

        // PLAYERS
        modelBuilder.Entity<Players>().ToTable("Players");
        modelBuilder.Entity<Players>().HasKey(p => p.PlayerId);
        modelBuilder.Entity<Players>().Property(p => p.PlayerId).HasColumnName("PlayerId");
        modelBuilder.Entity<Players>().Property(p => p.Nick);
        modelBuilder.Entity<Players>().Property(p => p.Tag);
        modelBuilder.Entity<Players>().Property(p => p.Server);
        modelBuilder.Entity<Players>().Property(p => p.Rank);
        modelBuilder.Entity<Players>().Property(p => p.MatchesWon);
        modelBuilder.Entity<Players>().Property(p => p.MatchesLost);
        modelBuilder.Entity<Players>()
            .HasMany(p => p.MatchPlayers)
            .WithOne(mp => mp.Player)
            .HasForeignKey(mp => mp.PlayerId);

        // CHAMPIONS
        modelBuilder.Entity<Champions>().ToTable("Champions");
        modelBuilder.Entity<Champions>().HasKey(c => c.ChampionId);
        modelBuilder.Entity<Champions>().Property(c => c.ChampionName);
        modelBuilder.Entity<Champions>().Property(c => c.Description);
        modelBuilder.Entity<Champions>().Property(c => c.Difficulty);

        // ITEMS
        modelBuilder.Entity<Items>().ToTable("Items");
        modelBuilder.Entity<Items>().HasKey(i => i.ItemId);
        modelBuilder.Entity<Items>().Property(i => i.ItemName);
        modelBuilder.Entity<Items>().Property(i => i.Description);
        modelBuilder.Entity<Items>().Property(i => i.Price);
        modelBuilder.Entity<Items>().Property(i => i.Type);

        // BUILDS
        modelBuilder.Entity<Builds>().ToTable("Builds");
        modelBuilder.Entity<Builds>().HasKey(b => b.BuildId);
        modelBuilder.Entity<Builds>().Property(b => b.Name);
        modelBuilder.Entity<Builds>().HasOne(b => b.Champion)
            .WithMany(c => c.Builds)
            .HasForeignKey(b => b.ChampionId);

        // LANES
        modelBuilder.Entity<Lanes>().ToTable("Lanes");
        modelBuilder.Entity<Lanes>().HasKey(l => l.LaneId);
        modelBuilder.Entity<Lanes>().Property(l => l.LaneName);

        // CHAMPIONS ON LANE
        modelBuilder.Entity<ChampionsOnLane>().ToTable("ChampionsOnLane");
        modelBuilder.Entity<ChampionsOnLane>().HasKey(cl => new { cl.ChampionId, cl.LaneId });
        modelBuilder.Entity<ChampionsOnLane>()
            .HasOne(cl => cl.Champion)
            .WithMany(c => c.ChampionsOnLane)
            .HasForeignKey(cl => cl.ChampionId);
        modelBuilder.Entity<ChampionsOnLane>()
            .HasOne(cl => cl.Lane)
            .WithMany(l => l.ChampionsOnLane)
            .HasForeignKey(cl => cl.LaneId);

        // MATCHES
        modelBuilder.Entity<Matches>().ToTable("Matches");
        modelBuilder.Entity<Matches>().HasKey(m => m.MatchId);
        modelBuilder.Entity<Matches>().Property(m => m.MatchDate);
        modelBuilder.Entity<Matches>().Property(m => m.GameMode);
        modelBuilder.Entity<Matches>().Property(m => m.Duration);

        // MATCH PLAYERS
        modelBuilder.Entity<MatchPlayers>().ToTable("MatchPlayer");
        modelBuilder.Entity<MatchPlayers>().HasKey(mp => mp.PlayersMatchId);
        modelBuilder.Entity<MatchPlayers>().HasOne(mp => mp.Match)
            .WithMany(m => m.MatchPlayers)
            .HasForeignKey(mp => mp.MatchId);
        modelBuilder.Entity<MatchPlayers>().HasOne(mp => mp.Player)
            .WithMany(p => p.MatchPlayers)
            .HasForeignKey(mp => mp.PlayerId);
        modelBuilder.Entity<MatchPlayers>().HasOne(mp => mp.Champion)
            .WithMany(c => c.MatchPlayers)
            .HasForeignKey(mp => mp.ChampionId);

        // PLAYERS MATCH ITEMS
        modelBuilder.Entity<PlayersMatchItems>().ToTable("PlayersMatchItems");
        modelBuilder.Entity<PlayersMatchItems>().HasKey(pmi => new { pmi.PlayersMatchId, pmi.ItemId });
        modelBuilder.Entity<PlayersMatchItems>().HasOne(pmi => pmi.MatchPlayer)
            .WithMany(mp => mp.PlayersMatchItems)
            .HasForeignKey(pmi => pmi.PlayersMatchId);
        modelBuilder.Entity<PlayersMatchItems>().HasOne(pmi => pmi.Item)
            .WithMany(i => i.PlayersMatchItems)
            .HasForeignKey(pmi => pmi.ItemId);
    }
}
