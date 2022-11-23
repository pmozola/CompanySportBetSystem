using CompanySportBetSystem.Application.Domain;

namespace CompanySportBetSystem.Infrastructure.Database.DataSeed
{
    public class BettingUserData
    {
        public static IEnumerable<BettingUser> Get()
        {
            return new List<BettingUser>()
            {
               BettingUser.Create("mpawelm"),
               BettingUser.Create("gmarcing"),
               BettingUser.Create("fpawelf")
            };
        }
    }
}
