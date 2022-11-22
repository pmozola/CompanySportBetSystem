using CompanySportBetSystem.Application.Domain;
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
}

