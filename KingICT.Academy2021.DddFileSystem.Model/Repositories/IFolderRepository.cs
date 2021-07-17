using System.Collections.Generic;
using System.Threading.Tasks;
using KingICT.Academy2021.DddFileSystem.Infrastructure;

namespace KingICT.Academy2021.DddFileSystem.Model.Repositories
{
    public interface IFolderRepository : IRepository<Folder, string>
    {
        Task<IEnumerable<Folder>> GetSiblings(Folder root);
    }
}
