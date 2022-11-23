using CompanySportBetSystem.Application.Domain;
using CompanySportBetSystem.Application.Projections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanySportBetSystem.Infrastructure.Database.Config;

public class GameEntityConfig : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.HomeTeamName).IsRequired();
        builder.Property(x => x.AwayTeamName).IsRequired();
        builder.Property(x => x.League).IsRequired();
        builder.Ignore(x => x.DomainEvents);

        builder.HasMany(x => x.Bets);
    }
}

public class ScoreBetEntityConfig : IEntityTypeConfiguration<ScoreBet>
{
    public void Configure(EntityTypeBuilder<ScoreBet> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserUd).IsRequired();
        builder.Property(x => x.Away).IsRequired();
        builder.Property(x => x.Home).IsRequired();
    }
}

public class BettingUserEntityConfig : IEntityTypeConfiguration<BettingUser>
{
    public void Configure(EntityTypeBuilder<BettingUser> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nick).IsRequired();
    }
}

public class TablePositionEntityConfig : IEntityTypeConfiguration<TablePosition>
{
    public void Configure(EntityTypeBuilder<TablePosition> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.DirectScore).IsRequired();
        builder.Property(x => x.LeagueId).IsRequired();
        builder.Property(x => x.Points).IsRequired();
        builder.Property(x => x.UserName).IsRequired();
    }
}
