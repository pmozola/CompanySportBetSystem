using FluentValidation;
using MediatR;

namespace CompanySportBetSystem.Application.Handlers.Commands
{
    public class AddScoreCommandHandler : IRequestHandler<AddScoreCommand, AddScoreResult>
    {
        public Task<AddScoreResult> Handle(AddScoreCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public record AddScoreCommand() : IRequest<AddScoreResult>;

    public record AddScoreResult();

    public sealed class AddScoreCommandValidator : AbstractValidator<AddScoreCommand>
    {
        public AddScoreCommandValidator()
        {

        }
    }
}
