using System.Threading.Tasks;
using KingICT.Academy2021.DddFileSystem.Messaging.Folder;

namespace KingICT.Academy2021.DddFileSystem.Contract
{
    public interface IFolderService
    {
        Task<GetFoldersResponse> GetAllFolders(GetFoldersRequest request);
        Task<CreateFolderResponse> CreateFolder(CreateFolderRequest request);
        Task<CreateSubFolderResponse> CreateSubFolder(CreateSubFolderRequest request);
        Task<DeleteFolderResponse> DeleteFolder(DeleteFolderRequest request);
    }
}
