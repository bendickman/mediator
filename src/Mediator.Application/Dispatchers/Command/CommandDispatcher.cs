using Mediator.Application.Interfaces.Command;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Application.Dispatchers.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellationToken)
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TCommandResult>>();

            return handler.Handle(command, cancellationToken);
        }
    }
}
