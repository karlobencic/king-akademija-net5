namespace KingICT.Academy2021.DddFileSystem.Messaging.Folder
{
    public class CreateFolderResponse : ResponseBase<CreateFolderRequest>
    {
        public FolderView Folder { get; set; }
    }
}
