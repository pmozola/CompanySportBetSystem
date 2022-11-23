namespace CompanySportBetSystem.Application.Projections
{
    public class TablePosition
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int Points { get; set; }
        public int DirectScore { get; set; }
    }
}
