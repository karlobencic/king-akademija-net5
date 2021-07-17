using System.Threading.Tasks;
using KingICT.Academy2021.DddFileSystem.Messaging.File;

namespace KingICT.Academy2021.DddFileSystem.Contract
{
    public interface IFileService
    {
        Task<GetFilesResponse> GetFiles(GetFilesRequest request);
        Task<CreateFileResponse> CreateFile(CreateFileRequest request);
        Task<SearchFilesResponse> SearchFiles(SearchFilesRequest request);
        Task<DeleteFileResponse> DeleteFile(DeleteFileRequest request);
    }
}
