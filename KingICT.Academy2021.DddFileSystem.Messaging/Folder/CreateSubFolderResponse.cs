namespace KingICT.Academy2021.DddFileSystem.Messaging.Folder
{
    public class CreateSubFolderResponse : ResponseBase<CreateSubFolderRequest>
    {
        public FolderView SubFolder { get; set; }
    }
}
