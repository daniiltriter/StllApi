﻿using Stll.CQRS.Abstractions;
using Stll.CQRS.Commands;
using Stll.CQRS.Results;

namespace Stll.CQRS.Handlers;

public abstract class RemoveCatcherHandler : ICatcherHandler<RemoveCatcherCommand, RemoveCatcherResult>
{
    public abstract Task<RemoveCatcherResult> ExecuteAsync(RemoveCatcherCommand command,
        CancellationToken cancellationToken);
}