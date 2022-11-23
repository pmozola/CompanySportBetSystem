using CompanySportBetSystem.Application.Domain;
using CompanySportBetSystem.Application.Projections;
using CompanySportBetSystem.Infrastructure.Database.Config;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanySportBetSystem.Infrastructure.Database;

public class BetDbContext : DbContext
{
    private readonly IMediator _mediator;

    public BetDbContext(DbContextOptions<BetDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeagueEntityConfig).Assembly);
    }

    public DbSet<League> Leagues { get; set; } = null!;
    public DbSet<Game> Games { get; set; } = null!;
    public DbSet<ScoreBet> Bets { get; set; } = null!;
    public DbSet<BettingUser> BettingUser { get; set; } = null!;
    public DbSet<TablePosition> TablePositions { get; set; } = null!;


    public async Task SaveDomainEntityAsync(CancellationToken cancellationToken = default)
    {
        await DispachDomainEvents();

        await base.SaveChangesAsync(cancellationToken);
    }

    private async Task DispachDomainEvents()
    {
        var domainEntities =
            this.ChangeTracker
                .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();
        
        foreach (var domainEvent in domainEvents)
            await _mediator.Publish(domainEvent);
    }
}

