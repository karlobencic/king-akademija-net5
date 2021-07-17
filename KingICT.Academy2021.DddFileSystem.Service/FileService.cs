using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KingICT.Academy2021.DddFileSystem.Contract;
using KingICT.Academy2021.DddFileSystem.Messaging.File;
using KingICT.Academy2021.DddFileSystem.Model.Repositories;
using KingICT.Academy2021.DddFileSystem.Service.Mapping;
using Microsoft.Extensions.Logging;

namespace KingICT.Academy2021.DddFileSystem.Service
{
    public class FileService : ServiceBase, IFileService
    {
        private readonly IFolderRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<IFileService> _logger;

        public FileService(IFolderRepository repository, IMapper mapper, ILogger<IFileService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetFilesResponse> GetFiles(GetFilesRequest request)
        {
            var response = new GetFilesResponse
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                var folder = await _repository.FindBy(f => f.Id == request.FolderId, i => i.Files);
                if (folder == null)
                {
                    return ResourceNotFound<GetFilesRequest, GetFilesResponse>(response);
                }

                response.Files = folder.Files.MapToView(_mapper);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response = GenericException<GetFilesRequest, GetFilesResponse>(response);
            }

            return response;
        }

        public async Task<CreateFileResponse> CreateFile(CreateFileRequest request)
        {
            var response = new CreateFileResponse
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                var folder = await _repository.FindBy(f => f.Id == request.NewFile.FolderId, i => i.Files);
                if (folder == null)
                {
                    return ResourceNotFound<CreateFileRequest, CreateFileResponse>(response);
                }

                var newFile = request.NewFile.MapToModel(_mapper);

                folder.AddFile(newFile);

                await _repository.Update(folder);

                response.File = newFile.MapToView(_mapper);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response = GenericException<CreateFileRequest, CreateFileResponse>(response);
            }

            return response;
        }

        public async Task<SearchFilesResponse> SearchFiles(SearchFilesRequest request)
        {
            var response = new SearchFilesResponse
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                var folders = await _repository.FindAll(i => i.Files);
                if (folders == null)
                {
                    return ResourceNotFound<SearchFilesRequest, SearchFilesResponse>(response);
                }

                var files = folders
                    .Where(folder => folder.Files != null)
                    .SelectMany(folder => folder.Files)
                    .Where(file => file.Name.StartsWith(request.FileName, StringComparison.OrdinalIgnoreCase))
                    .Take(10);

                response.Files = files.MapToView(_mapper);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response = GenericException<SearchFilesRequest, SearchFilesResponse>(response);
            }

            return response;
        }

        public async Task<DeleteFileResponse> DeleteFile(DeleteFileRequest request)
        {
            var response = new DeleteFileResponse
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                var folder = await _repository.FindBy(f => f.Id == request.FolderId, i => i.Files);
                if (folder == null)
                {
                    return ResourceNotFound<DeleteFileRequest, DeleteFileResponse>(response);
                }

                var file = folder.Files.SingleOrDefault(f => f.Id == request.FileId);
                if (file == null)
                {
                    return ContentNotFound<DeleteFileRequest, DeleteFileResponse>(response);
                }

                folder.RemoveFile(file);

                await _repository.Update(folder);

                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response = GenericException<DeleteFileRequest, DeleteFileResponse>(response);
            }

            return response;
        }
    }
}
