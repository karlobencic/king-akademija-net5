using AutoMapper;
using KingICT.Academy2021.DddFileSystem.Messaging.Folder;
using KingICT.Academy2021.DddFileSystem.Model;

namespace KingICT.Academy2021.DddFileSystem.Service.Mapping
{
    public class FolderMappingProfile : Profile
    {
        public FolderMappingProfile()
        {
            CreateMap<Folder, FolderView>();
            CreateMap<FolderCreateView, Folder>();
        }
    }
}
