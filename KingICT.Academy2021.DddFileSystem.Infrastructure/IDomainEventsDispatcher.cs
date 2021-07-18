using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingICT.Academy2021.DddFileSystem.Infrastructure
{
    public interface IDomainEventsDispatcher
    {
        Task Publish(IList<IDomainEvent> domainEvents);
    }
}
