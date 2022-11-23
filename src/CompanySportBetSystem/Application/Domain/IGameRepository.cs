namespace CompanySportBetSystem.Application.Domain
{
    public interface IGameRepository
    {
        Task Update(Game entity, CancellationToken cancellationToken = default);
        Task<Game> Get(int requestGameId);
    }
}
