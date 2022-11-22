using CompanySportBetSystem.Application.Handlers.Commands;
using CompanySportBetSystem.Infrastructure.Database;
using CompanySportBetSystem.Infrastructure.Database.DataSeed;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanySportBetSystem
{
    public static class IoCConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddMediatR(typeof(AddScoreCommandHandler).Assembly)
                // .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                // .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>))
                .AddValidatorsFromAssemblyContaining<AddScoreCommandValidator>();

            services.AddDbContext<BetDbContext>(
                options => options.UseInMemoryDatabase("BetSystem"));

            services
                .AddTransient<Seeder>();

            return services;
        }
    }
}
