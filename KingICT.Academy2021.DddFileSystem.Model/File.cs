using KingICT.Academy2021.DddFileSystem.Infrastructure;

namespace KingICT.Academy2021.DddFileSystem.Model
{
    public class File : EntityBase<int>
    {
        public string Name { get; set; }
        public int FolderId { get; set; }

        public virtual Folder Folder { get; set; }

        private File()
        {
        }
    }
}
