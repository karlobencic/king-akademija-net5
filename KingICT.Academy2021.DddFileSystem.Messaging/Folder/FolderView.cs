using System.Collections.Generic;
using KingICT.Academy2021.DddFileSystem.Messaging.File;

namespace KingICT.Academy2021.DddFileSystem.Messaging.Folder
{
    public class FolderView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FolderView Parent { get; set; }
        public IEnumerable<FolderView> SubFolders { get; set; }
        public IEnumerable<FileView> Files { get; set; }
    }
}
