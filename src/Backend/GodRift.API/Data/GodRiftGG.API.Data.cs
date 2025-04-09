using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using GodRift.API.Models;
using GodRiftGG.Models;
using GodRiftGG.API.Models;

namespace GodRiftGG.API.Data;

public class GodRiftGGContext : DbContext
{
    public GodRiftGGContext(DbContextOptions<GodRiftGGContext> options) : base(options) { }

    public DbSet<User> User { get; set; }
    public DbSet<Player> Player { get; set; }
    public DbSet<Champion> Champion { get; set; }
    public DbSet<Items> Items { get; set; }
    public DbSet<Build> Build { get; set; }
    public DbSet<Lane> Lane { get; set; }
    public DbSet<ChampionsOnLane> ChampionsOnLane { get; set; }
    public DbSet<Match> Match { get; set; }
    public DbSet<MatchPlayer> MatchPlayer { get; set; }
    public DbSet<PlayersMatchItem> PlayerMatchItems { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<User>().HasKey(u => u.UserId);
        modelBuilder.Entity<User>().Property(u => u.UserId).HasColumnName("UserId");
        modelBuilder.Entity<User>().Property(u => u.Name);
        modelBuilder.Entity<User>().Property(u => u.Email);
        modelBuilder.Entity<User>().Property(u => u.HashPassword);
        modelBuilder.Entity<User>().Property(u => u.CreatedAt);

        // Player
        modelBuilder.Entity<Player>().ToTable("Player");
        modelBuilder.Entity<Player>().HasKey(p => p.PlayerId);
        modelBuilder.Entity<Player>().Property(p => p.PlayerId).HasColumnName("PlayerId");
        modelBuilder.Entity<Player>().Property(p => p.Nick);
        modelBuilder.Entity<Player>().Property(p => p.Tag);
        modelBuilder.Entity<Player>().Property(p => p.Server);
        modelBuilder.Entity<Player>().Property(p => p.Rank);
        modelBuilder.Entity<Player>().Property(p => p.MatchesWon);
        modelBuilder.Entity<Player>().Property(p => p.MatchesLost);
        modelBuilder.Entity<Player>()
            .HasMany(p => p.MatchPlayer)
            .WithOne(mp => mp.Player)
            .HasForeignKey(mp => mp.PlayerId);

        // Champion
        modelBuilder.Entity<Champion>().ToTable("Champion");
        modelBuilder.Entity<Champion>().HasKey(c => c.ChampionId);
        modelBuilder.Entity<Champion>().Property(c => c.ChampionName);
        modelBuilder.Entity<Champion>().Property(c => c.Description);
        modelBuilder.Entity<Champion>().Property(c => c.Difficulty);

        // ITEMS
        modelBuilder.Entity<Items>().ToTable("Items");
        modelBuilder.Entity<Items>().HasKey(i => i.ItemId);
        modelBuilder.Entity<Items>().Property(i => i.ItemName);
        modelBuilder.Entity<Items>().Property(i => i.Description);
        modelBuilder.Entity<Items>().Property(i => i.Price);
        modelBuilder.Entity<Items>().Property(i => i.Type);

        // Build
        modelBuilder.Entity<Build>().ToTable("Build");
        modelBuilder.Entity<Build>().HasKey(b => b.BuildId);
        modelBuilder.Entity<Build>().Property(b => b.Name);
        modelBuilder.Entity<Build>().HasOne(b => b.Champion)
            .WithMany(c => c.Builds)
            .HasForeignKey(b => b.ChampionId);

        // Lane
        modelBuilder.Entity<Lane>().ToTable("Lane");
        modelBuilder.Entity<Lane>().HasKey(l => l.LaneId);
        modelBuilder.Entity<Lane>().Property(l => l.LaneName);

        // Champion ON LANE
        modelBuilder.Entity<ChampionsOnLane>().ToTable("ChampionsOnLane");
        modelBuilder.Entity<ChampionsOnLane>().HasKey(cl => new { cl.ChampionId, cl.LaneId });
        modelBuilder.Entity<ChampionsOnLane>()
            .HasOne(cl => cl.Champion)
            .WithMany(c => c.ChampionsOnLanes)
            .HasForeignKey(cl => cl.ChampionId);
        modelBuilder.Entity<ChampionsOnLane>()
            .HasOne(cl => cl.Lane)
            .WithMany(l => l.ChampionsOnLanes)
            .HasForeignKey(cl => cl.LaneId);

        // Match
        modelBuilder.Entity<Match>().ToTable("Match");
        modelBuilder.Entity<Match>().HasKey(m => m.MatchId);
        modelBuilder.Entity<Match>().Property(m => m.MatchDate);
        modelBuilder.Entity<Match>().Property(m => m.GameMode);
        modelBuilder.Entity<Match>().Property(m => m.Duration);

        // MATCH Player
        modelBuilder.Entity<MatchPlayer>().ToTable("MatchPlayer");
        modelBuilder.Entity<MatchPlayer>().HasKey(mp => mp.PlayersMatchId);
        modelBuilder.Entity<MatchPlayer>().HasOne(mp => mp.Match)
            .WithMany(m => m.MatchPlayers)
            .HasForeignKey(mp => mp.MatchId);
        modelBuilder.Entity<MatchPlayer>().HasOne(mp => mp.Player)
            .WithMany(p => p.MatchPlayer)
            .HasForeignKey(mp => mp.PlayerId);
        modelBuilder.Entity<MatchPlayer>().HasOne(mp => mp.Champion)
            .WithMany(c => c.MatchPlayers)
            .HasForeignKey(mp => mp.ChampionId);

        // Player MATCH ITEMS
        modelBuilder.Entity<PlayersMatchItem>().ToTable("PlayerMatchItems");
        modelBuilder.Entity<PlayersMatchItem>().HasKey(pmi => new { pmi.PlayersMatchId, pmi.ItemId });
        modelBuilder.Entity<PlayersMatchItem>().HasOne(pmi => pmi.MatchPlayer)
            .WithMany(mp => mp.Items)
            .HasForeignKey(pmi => pmi.PlayersMatchId);
        modelBuilder.Entity<PlayersMatchItem>().HasOne(pmi => pmi.Item)
            .WithMany(i => i.PlayersMatchItems)
            .HasForeignKey(pmi => pmi.ItemId);
    }
}
