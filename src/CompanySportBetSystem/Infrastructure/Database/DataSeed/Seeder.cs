namespace CompanySportBetSystem.Infrastructure.Database.DataSeed
{

    public class Seeder
    {
        private readonly BetDbContext _dBContext;

        public Seeder(BetDbContext dBContext)
        {
            this._dBContext = dBContext;
        }

        public void Seed()
        {
            if (_dBContext.Leagues.Any()) return;

            _dBContext.Leagues.AddRangeAsync(LeagueData.Get());
            var leagueId = _dBContext.Leagues.FirstOrDefault()!.Id;
            _dBContext.Games.AddRangeAsync(GameData.Get(leagueId));
            _dBContext.BettingUser.AddRange(BettingUserData.Get());

            _dBContext.SaveChanges();
        }
    }

    public static class DataSeeder
    {
        public static IServiceProvider SeedData(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            scope.ServiceProvider.GetRequiredService<Seeder>().Seed();

            return services;
        }
    }
}

