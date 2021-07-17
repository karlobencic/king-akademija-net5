using KingICT.Academy2021.DddFileSystem.Messaging.Folder;

namespace KingICT.Academy2021.DddFileSystem.Messaging.File
{
    public class FileView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FolderView Folder { get; set; }
    }
}
