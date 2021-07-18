using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KingICT.Academy2021.DddFileSystem.Contract;
using KingICT.Academy2021.DddFileSystem.Infrastructure;
using KingICT.Academy2021.DddFileSystem.Messaging.Folder;
using KingICT.Academy2021.DddFileSystem.Model;
using KingICT.Academy2021.DddFileSystem.Model.Repositories;
using KingICT.Academy2021.DddFileSystem.Service.Mapping;
using Microsoft.Extensions.Logging;

namespace KingICT.Academy2021.DddFileSystem.Service
{
    public class FolderService : ServiceBase, IFolderService
    {
        private readonly IFolderRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<IFolderService> _logger;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public FolderService(IFolderRepository repository, IMapper mapper, ILogger<IFolderService> logger, IDomainEventsDispatcher domainEventsDispatcher)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task<GetFoldersResponse> GetAllFolders(GetFoldersRequest request)
        {
            var response = new GetFoldersResponse
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                var folders = await _repository.FindAll
                    (
                        i => i.Parent, 
                        i => i.Files, 
                        i => i.SubFolders
                    );

                if (folders == null)
                {
                    return ResourceNotFound<GetFoldersRequest, GetFoldersResponse>(response);
                }

                response.Folders = folders.MapToView(_mapper);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response = GenericException<GetFoldersRequest, GetFoldersResponse>(response);
            }

            return response;
        }

        public async Task<CreateFolderResponse> CreateFolder(CreateFolderRequest request)
        {
            var response = new CreateFolderResponse
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                var folder = request.NewFolder.MapToModel(_mapper);

                await _repository.Add(folder);

                response.Folder = folder.MapToView(_mapper);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response = GenericException<CreateFolderRequest, CreateFolderResponse>(response);
            }

            return response;
        }

        public async Task<CreateSubFolderResponse> CreateSubFolder(CreateSubFolderRequest request)
        {
            var response = new CreateSubFolderResponse
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                var parent = await _repository.FindBy
                    (
                        f => f.Id == request.ParentId, 
                        i => i.Parent,
                        i => i.SubFolders
                    );

                if (parent == null)
                {
                    return ResourceNotFound<CreateSubFolderRequest, CreateSubFolderResponse>(response);
                }

                var subFolder = request.NewFolder.MapToModel(_mapper);

                subFolder.SetParent(parent);

                await _repository.Add(subFolder);

                response.SubFolder = subFolder.MapToView(_mapper);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response = GenericException<CreateSubFolderRequest, CreateSubFolderResponse>(response);
            }

            return response;
        }

        public async Task<DeleteFolderResponse> DeleteFolder(DeleteFolderRequest request)
        {
            var response = new DeleteFolderResponse
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                var folder = await _repository.FindBy
                (
                    f => f.Id == request.Id,
                    i => i.Parent,
                    i => i.Files,
                    i => i.SubFolders
                );

                if (folder == null)
                {
                    return ResourceNotFound<DeleteFolderRequest, DeleteFolderResponse>(response);
                }

                var siblings = await _repository.GetSiblings(folder) as List<Folder>;

                await _repository.RemoveRange(siblings);
                await _repository.Remove(folder);

                folder.SetDeleted();
                siblings.ForEach(f => f.SetDeleted());

                await _domainEventsDispatcher.Publish(folder.DomainEvents.Union(siblings.SelectMany(s => s.DomainEvents)).ToList());

                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response = GenericException<DeleteFolderRequest, DeleteFolderResponse>(response);
            }

            return response;
        }
    }
}
