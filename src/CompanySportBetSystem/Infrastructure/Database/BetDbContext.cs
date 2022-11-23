using CompanySportBetSystem.Application.Domain;
using CompanySportBetSystem.Application.Projections;
using CompanySportBetSystem.Infrastructure.Database.Config;
using Microsoft.EntityFrameworkCore;

namespace CompanySportBetSystem.Infrastructure.Database;

public class BetDbContext : DbContext
{
    public BetDbContext(DbContextOptions<BetDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeagueEntityConfig).Assembly);
    }

    public DbSet<League> Leagues { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<ScoreBet> Bets { get; set; }
    public DbSet<BettingUser> BettingUser { get; set; }
    public DbSet<TablePosition> TablePositions { get; set; }
}

