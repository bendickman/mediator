﻿namespace Mediator.Application.Interfaces.Command
{
    public interface ICommandHandler<in TCommand, TCommandResult>
    {
        Task<TCommandResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}
