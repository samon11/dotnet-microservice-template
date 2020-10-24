﻿using BuildingBlocks.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Template.Infrastructure;
using Template.Domain.Events;
using Template.Domain.Aggregates;

namespace Template.Api.EventHandlers
{
    public class TemplateCreatedEventHandler : IEventHandler<TemplateCreatedEvent>
    {
        private readonly ITemplateEntityRepository _entities;
        // private readonly ILogger _logger;

        public TemplateCreatedEventHandler(ITemplateEntityRepository entities)
        {
            // _logger = logger;
            _entities = entities;
        }

        public Task Handle(TemplateCreatedEvent @event)
        {
            // _logger.LogInformation("Created new transfer : " + @event.Amount);
            _entities.Create(new TemplateEntity(@event.TemplateID));

            return Task.CompletedTask;
        }
    }
}
