using System.ComponentModel.DataAnnotations;

namespace KingICT.Academy2021.DddFileSystem.Messaging.Folder
{
    public class FolderCreateView
    {
        [Required]
        public string Name { get; set; }
    }
}
