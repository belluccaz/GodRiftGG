using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using GodRift.API.Models;
using GodRiftGG.Models;

namespace GodRift.API.Data;

public class GodRiftContext : DbContext
{
    public GodRiftContext(DbContextOptions<GodRiftContext> options) : base(options) { }

    public DbSet<Users> Userss => Set<Users>();
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

        // TABELAS
        modelBuilder.Entity<Users>().ToTable("Users");
        modelBuilder.Entity<Users>().HasKey(u => u.UserId);
        modelBuilder.Entity<Users>().Property(u => u.UserId).HasColumnName("UserId");
        modelBuilder.Entity<Users>().Property(u => u.Name);
        modelBuilder.Entity<Users>().Property(u => u.Email);
        modelBuilder.Entity<Users>().Property(u => u.HashPassword);
        modelBuilder.Entity<Users>().Property(u => u.CreatedAt);

        // faça o mesmo para as demais entidades...

        // EXEMPLO DE TABELA COMPOSITE KEY
        modelBuilder.Entity<ChampionsOnLane>()
            .HasKey(cl => new { cl.ChampionId, cl.LaneId });
    }
}
