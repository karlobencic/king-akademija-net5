using System.ComponentModel.DataAnnotations;

namespace KingICT.Academy2021.DddFileSystem.Messaging.File
{
    public class FileCreateView
    {
        [Required]
        public string Name { get; set; }
        [Required] 
        public int FolderId { get; set; }
    }
}