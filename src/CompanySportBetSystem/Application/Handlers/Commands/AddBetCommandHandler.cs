using CompanySportBetSystem.Application.Domain;
using FluentValidation;
using MediatR;

namespace CompanySportBetSystem.Application.Handlers.Commands
{
    public class AddBetCommandHandler : IRequestHandler<AddBetCommand, AddBetResult>
    {
        private readonly IGameRepository _repository;

        public AddBetCommandHandler(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddBetResult> Handle(AddBetCommand request, CancellationToken cancellationToken)
        {
            var game = await _repository.Get(request.GameId);
            if (game == null) throw new NotFoundException();
            var bet = ScoreBet.Create(request.HomeTeam, request.AwayTeam, request.UserId);

            game.AddBet(bet);

            await _repository.Update(game, cancellationToken);

            return new AddBetResult();
        }
    }

    public class NotFoundException : Exception
    {
    }

    public record AddBetCommand(Guid UserId, int GameId, int HomeTeam, int AwayTeam) : IRequest<AddBetResult>;

    public record AddBetResult();

    public sealed class AddScoreCommandValidator : AbstractValidator<AddBetCommand>
    {
        public AddScoreCommandValidator()
        {
            // TODO Add validation Logic
        }
    }
}
