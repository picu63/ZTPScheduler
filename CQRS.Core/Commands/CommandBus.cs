﻿using System.Threading;
using System.Threading.Tasks;
using CQRS.MediatR.Command;
using MediatR;

namespace CQRS.Core.Commands
{
    public class CommandBus : ICommandBus
    {
        private readonly IMediator _mediator;

        public CommandBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Send<TCommand>(TCommand request, CancellationToken cancellationToken = default) where TCommand : ICommand
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}