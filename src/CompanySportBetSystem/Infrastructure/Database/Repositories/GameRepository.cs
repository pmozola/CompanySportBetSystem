using CompanySportBetSystem.Application.Domain;
using Microsoft.EntityFrameworkCore;

namespace CompanySportBetSystem.Infrastructure.Database.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly BetDbContext _dbContext;

        public GameRepository(BetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Update(Game entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Games.Update(entity);

            return _dbContext.SaveDomainEntityAsync(cancellationToken);
        }

        public Task<Game> Get(int requestGameId, CancellationToken cancellationToken = default)
        {
            return _dbContext
                .Games
                .FirstAsync(
                    x => x.Id == requestGameId, cancellationToken: cancellationToken);
        }
    }
}
