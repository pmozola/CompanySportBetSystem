using CompanySportBetSystem.Application.Domain;
using CompanySportBetSystem.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanySportBetSystem.Application.Projections
{
    public class GameFinishedEventHandler : INotificationHandler<GameFinishedEvent>
    {
        private readonly BetDbContext _dbContext;

        public GameFinishedEventHandler(BetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(GameFinishedEvent notification, CancellationToken cancellationToken)
        {
            var game = await _dbContext.Games.FirstAsync(x => x.Id == notification.GameId, cancellationToken);
            var tablePositions = await _dbContext.TablePositions.Where(x => x.LeagueId == game.League).ToListAsync(cancellationToken);

            foreach (var bet in game.Bets)
            {
                var userTablePostion = await GetUserTablePosition(bet, tablePositions, notification, game.League);
                
                UpdateUserScore(bet, userTablePostion, notification);

                _dbContext.Update(userTablePostion);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        private static void UpdateUserScore(ScoreBet bet, TablePosition userTablePostion, GameFinishedEvent @event)
        {
            if (bet.Away == @event.AwayScore && bet.Home == @event.HomeScore)
            {
                userTablePostion.DirectScore++;
                userTablePostion.Points += 3;
            }else if(
                @event.AwayScore > @event.HomeScore && bet.Away > bet.Home ||
                @event.AwayScore < @event.HomeScore && bet.Away < bet.Home ||
                @event.AwayScore == @event.HomeScore && bet.Away == bet.Home)
            {
                userTablePostion.Points ++;
            }
        }


        public async Task<TablePosition> GetUserTablePosition(ScoreBet score, List<TablePosition> table, GameFinishedEvent @event, int leagueId)
        {
            var tablePosition = table.FirstOrDefault(x => x.UserId == score.UserUd);

           if( tablePosition == null)
           {
               var userNick = (await _dbContext.BettingUser.FirstAsync(x => x.Id == score.UserUd)).Nick;
               tablePosition = new TablePosition
                   { DirectScore = 0, Points = 0, LeagueId = leagueId, UserId = score.UserUd, UserName = userNick };
           }

           _dbContext.Add(tablePosition);
           return tablePosition;
        }

    }
}
