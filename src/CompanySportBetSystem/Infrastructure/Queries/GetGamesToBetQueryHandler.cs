using CompanySportBetSystem.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanySportBetSystem.Infrastructure.Queries
{
    public class GetGamesToBetQueryHandler : IRequestHandler<GetGamesToBetQuery, List<GameViewModel>>
    {
        private readonly BetDbContext _dbContext;

        public GetGamesToBetQueryHandler(BetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<GameViewModel>> Handle(GetGamesToBetQuery request, CancellationToken cancellationToken)
        {
            return _dbContext.Games.Where(x =>
                x.Date > DateTime.Now)
                // x.Bets.All(z => z.UserUd != request.UserId))
                .Select(x => new GameViewModel(x.Id, x.HomeTeamName, x.HomeTeamName))
                .ToListAsync(cancellationToken);
        }
    }

    public record GetGamesToBetQuery() : IRequest<List<GameViewModel>>;
    public record GameViewModel(int GameId, string HomeTeamName, string AwayTeamName);
}
