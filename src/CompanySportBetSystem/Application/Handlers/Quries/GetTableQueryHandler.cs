using CompanySportBetSystem.Application.Projections;
using CompanySportBetSystem.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanySportBetSystem.Application.Handlers.Quries
{
    public class GetTableQueryHandler : IRequestHandler<GetTableQuery, List<TablePosition>>
    {
        private readonly BetDbContext _dbContext;

        public GetTableQueryHandler(BetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  Task<List<TablePosition>> Handle(GetTableQuery request, CancellationToken cancellationToken)
        {
            return
                _dbContext
                    .TablePositions
                    .Where(x => x.LeagueId == request.LeagueId)
                    .ToListAsync(cancellationToken);
        }
    }
    
    public record GetTableQuery(int LeagueId) : IRequest<List<TablePosition>>;
}
