namespace KingICT.Academy2021.DddFileSystem.Messaging.File
{
    public class CreateFileRequest : RequestBase
    {
        public FileCreateView NewFile { get; set; }
    }
}
