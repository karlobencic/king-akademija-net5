using KingICT.Academy2021.DddFileSystem.Infrastructure;

namespace KingICT.Academy2021.DddFileSystem.Model.Events
{
    public class FolderDeletedEvent : DomainEventBase
    {
        public Folder Folder { get; }

        public FolderDeletedEvent(Folder folder)
        {
            Folder = folder;
        }
    }
}
