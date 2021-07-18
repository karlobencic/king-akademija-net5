using System.Threading;
using System.Threading.Tasks;
using KingICT.Academy2021.DddFileSystem.Infrastructure;
using KingICT.Academy2021.DddFileSystem.Model.Events;

namespace KingICT.Academy2021.DddFileSystem.Service.EventHandlers
{
    internal class FolderDeletedEventHandler : DomainEventHandlerBase<FolderDeletedEvent>
    {
        public override async Task Handle(FolderDeletedEvent notification, CancellationToken cancellationToken)
        {
            // dispatch message
        }
    }
}
