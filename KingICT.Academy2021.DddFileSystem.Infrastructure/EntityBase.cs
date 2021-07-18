using System.Collections.Generic;

namespace KingICT.Academy2021.DddFileSystem.Infrastructure
{
    public abstract class EntityBase<TId>
    {
        public TId Id { get; set; }

        private List<IDomainEvent> _domainEvents;

        public List<IDomainEvent> DomainEvents => _domainEvents;

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents ??= new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        public override bool Equals(object entity)
        {
            return entity is EntityBase<TId> && this == (EntityBase<TId>)entity;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            return !(entity1 == entity2);
        }
    }
}
