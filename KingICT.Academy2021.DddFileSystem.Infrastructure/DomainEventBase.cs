using System;
using MediatR;

namespace KingICT.Academy2021.DddFileSystem.Infrastructure
{
    /// <summary>
    /// Base class for domain event. Implements INotification for MediatrR usage.
    /// </summary>
    public abstract class DomainEventBase : IDomainEvent, INotification
    {
        public DateTime OccurredOn { get; }

        protected DomainEventBase(DateTime? occurredOn = null)
        {
            OccurredOn = occurredOn ?? DateTime.UtcNow;
        }
    }
}
