using MediatR;

namespace CompanySportBetSystem.Application.Domain;

public class Game
{
    public int Id { get; }
    public string HomeTeamName { get; init; } = string.Empty;
    public string AwayTeamName { get; init; } = string.Empty;
    public DateTime Date { get; init; }
    public int League { get; init; }
    public List<ScoreBet> Bets { get; } = new();
    public int HomeTeamScore { get; private set; }
    public int AwayTeamScore { get; private set; }

    public void AddBet(ScoreBet bet)
    {
        if (Date <= DateTime.Now) throw new InvalidOperationException("Too late....");
        if (Bets.Any(x => x.UserUd == bet.UserUd)) throw new InvalidOperationException("User already bet....");

        Bets.Add(bet);
    }
    
    public void AddFinalGameScore(int home, int away)
    {
        if (home < 0 || away < 0) throw new InvalidDataException("score can not be negative....");
        HomeTeamScore = home;
        AwayTeamScore = away;
    }
}

public record GameFinishedEvent(int GameId, int HomeScore, int AwayScore) : INotification;

public class League : IAggregateRoot
{

    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}

public interface IAggregateRoot
{
    int Id { get; }
}

public class ScoreBet
{
    private ScoreBet() { }

    public static ScoreBet Create(int homeScore, int awayScore, Guid userId)
    {
        if (homeScore < 0 || awayScore < 0) throw new InvalidDataException("Score cannot be with negative...");

        return new ScoreBet { Home = homeScore, Away = awayScore, UserUd = userId };
    }

    public int Id { get; }
    public int Home { get; init; }
    public int Away { get; init; }
    public Guid UserUd { get; init; }
}

public class BettingUser
{
    public Guid Id { get; init; }
    public string Nick { get; init; } = string.Empty;

    private BettingUser() { }

    public static BettingUser Create(string nick)
    {
        if (nick == string.Empty) throw new InvalidDataException("Nick should be filed...");

        return new BettingUser { Nick = nick };
    }
}