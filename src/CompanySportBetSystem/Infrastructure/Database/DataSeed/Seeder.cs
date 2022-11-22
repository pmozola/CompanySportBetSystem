namespace CompanySportBetSystem.Infrastructure.Database.DataSeed
{

    public class Seeder
    {
        private readonly BetDbContext dBContext;

        public Seeder(BetDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public void Seed()
        {
            dBContext.Leagues.AddRangeAsync(LeagueData.Get());

            dBContext.SaveChanges();
        }
    }

    public static class DataSeeder
    {
        public static IServiceProvider SeedData(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<Seeder>().Seed();
            }

            return services;
        }
    }
}

