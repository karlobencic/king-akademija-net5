using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace KingICT.Academy2021.DddFileSystem.Infrastructure
{
    /// <summary>
    /// Implementation of IDomainEventsDispatcher which uses MediatR to publish events.
    /// </summary>
    public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IMediator _mediator;

        public DomainEventsDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        async Task IDomainEventsDispatcher.Publish(IList<IDomainEvent> domainEvents)
        {
            var tasks = domainEvents?.Select(async d =>
            {
                if (d is DomainEventBase domainEvent)
                {
                    await _mediator.Publish(domainEvent);
                }
            });

            if (tasks != null)
            {
                await Task.WhenAll(tasks);
            }
        }
    }
}
