using CompanySportBetSystem.Application.Domain;

namespace CompanySportBetSystem.Infrastructure.Database.DataSeed
{
    public class GameData
    {
        public static IEnumerable<Game> Get(int leagueId)
        {
            return new List<Game>()
            {
                new Game
                {
                    League = leagueId,
                    HomeTeamName = "Marrocco",
                    AwayTeamName = "Croatia",
                    Date = new DateTime(2022,11,23,11,0,0)
                },
                new Game
                {
                League = leagueId,
                HomeTeamName = "Germany",
                AwayTeamName = "Japan",
                Date = new DateTime(2022,11,23,14,0,0)
                },
                new Game
                {
                    League = leagueId,
                    HomeTeamName = "Spain",
                    AwayTeamName = "Costa Rica",
                    Date = new DateTime(2022,11,23,11,0,0)
                },new Game
                {
                    League = leagueId,
                    HomeTeamName = "Belgium",
                    AwayTeamName = "Canada",
                    Date = new DateTime(2022,11,23,11,0,0)
                }
            };
        }
    }
}
