namespace KingICT.Academy2021.DddFileSystem.Messaging.Folder
{
    public class CreateSubFolderRequest : RequestBase
    {
        public int ParentId { get; set; }
        public FolderCreateView NewFolder { get; set; }
    }
}
