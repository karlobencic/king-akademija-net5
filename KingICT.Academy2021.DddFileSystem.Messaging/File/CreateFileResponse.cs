namespace KingICT.Academy2021.DddFileSystem.Messaging.File
{
    public class CreateFileResponse : ResponseBase<CreateFileRequest>
    {
        public FileView File { get; set; }
    }
}
