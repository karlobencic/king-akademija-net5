namespace KingICT.Academy2021.DddFileSystem.Messaging.File
{
    public class DeleteFileRequest : RequestBase
    {
        public int FolderId { get; set; }
        public int FileId { get; set; }
    }
}
