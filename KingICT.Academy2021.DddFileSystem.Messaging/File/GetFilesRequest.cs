namespace KingICT.Academy2021.DddFileSystem.Messaging.File
{
    public class GetFilesRequest : RequestBase
    {
        public int FolderId { get; set; }
    }
}
