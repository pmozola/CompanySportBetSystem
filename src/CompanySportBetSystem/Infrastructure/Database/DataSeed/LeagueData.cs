using CompanySportBetSystem.Application.Domain;

namespace CompanySportBetSystem.Infrastructure.Database.DataSeed
{
    public class LeagueData
    {
        public static IEnumerable<League> Get()
        {
            return new List<League>()
            {
                new() {Name="Fifa World Cup" }
            };
        }
    }
}
