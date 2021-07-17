using System.Collections.Generic;
using KingICT.Academy2021.DddFileSystem.Infrastructure;

namespace KingICT.Academy2021.DddFileSystem.Model
{
    public class Folder : EntityBase<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual Folder Parent { get; set; }
        public virtual ICollection<Folder> SubFolders { get; set; }
        public virtual ICollection<File> Files { get; set; }

        private Folder()
        {
        }

        public void AddFile(File file)
        {
            if (Files == null)
            {
                Files = new List<File>
                {
                    file
                };
            }
            else
            {
                Files.Add(file);
            }
        }

        public void RemoveFile(File file)
        {
            Files.Remove(file);
        }

        public void SetParent(Folder folder)
        {
            Parent = folder;
        }
    }
}
