namespace KingICT.Academy2021.DddFileSystem.Messaging.Folder
{
    public class CreateFolderRequest : RequestBase
    {
        public FolderCreateView NewFolder { get; set; }
    }
}
