using Mediator.Application.Interfaces.Command;
using Mediator.Application.Interfaces.Query;
using Mediator.Infrastructure.Dispatchers.Command;
using Mediator.Infrastructure.Dispatchers.Query;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // INFO: cross-cutting concerns can be added using decorators
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>()
                .Decorate<ICommandDispatcher, CommandDispatcherDecorator>();

            services.AddSingleton<IQueryDispatcher, QueryDispatcher>()
                .Decorate<IQueryDispatcher, QueryDispatcherDectorator>();

            // INFO: Using https://www.nuget.org/packages/Scrutor for registering all Query and Command handlers by convention
            services.Scan(selector =>
            {
                selector.FromCallingAssembly()
                        .AddClasses(filter =>
                        {
                            filter.AssignableTo(typeof(IQueryHandler<,>));
                        })
                        .AsImplementedInterfaces()
                        .WithSingletonLifetime();
            });
            services.Scan(selector =>
            {
                selector.FromCallingAssembly()
                        .AddClasses(filter =>
                        {
                            filter.AssignableTo(typeof(ICommandHandler<,>));
                        })
                        .AsImplementedInterfaces()
                        .WithSingletonLifetime();
            });

            return services;
        }
    }
}
