using Mediator.Application.Interfaces.Command;
using System.Diagnostics;

namespace Mediator.Application.Dispatchers.Command
{
    public class CommandDispatcherDecorator : ICommandDispatcher
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CommandDispatcherDecorator(
            ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Do something before the command");

            var result = _commandDispatcher
                .Dispatch<TCommand, TCommandResult>(command, cancellationToken);

            Debug.WriteLine("Do something after the command");

            return result;
        }
    }
}
