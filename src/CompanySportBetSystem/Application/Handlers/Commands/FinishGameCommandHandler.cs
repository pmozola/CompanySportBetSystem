using CompanySportBetSystem.Application.Domain;
using FluentValidation;
using MediatR;

namespace CompanySportBetSystem.Application.Handlers.Commands
{
    public class FinishGameCommandHandler : IRequestHandler<FinishGameCommand, FinishGameResult>
    {
        private readonly IGameRepository _repository;

        public FinishGameCommandHandler(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<FinishGameResult> Handle(FinishGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _repository.Get(request.GameId);
            if (game == null) throw new NotFoundException();
            game.AddFinalGameScore(request.HomeTeam, request.AwayTeam);

            await _repository.Update(game, cancellationToken);

            return new FinishGameResult();
        }
    }

    public record FinishGameCommand(int GameId, int HomeTeam, int AwayTeam) : IRequest<FinishGameResult>;

    public record FinishGameResult();

    public sealed class FinishGameCommandValidator : AbstractValidator<FinishGameCommand>
    {
        public FinishGameCommandValidator()
        {
            // TODO Add validation Logic
        }
    }
}
