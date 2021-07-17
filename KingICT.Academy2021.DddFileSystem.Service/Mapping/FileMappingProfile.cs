using AutoMapper;
using KingICT.Academy2021.DddFileSystem.Messaging.File;
using KingICT.Academy2021.DddFileSystem.Model;

namespace KingICT.Academy2021.DddFileSystem.Service.Mapping
{
    public class FileMappingProfile : Profile
    {
        public FileMappingProfile()
        {
            CreateMap<File, FileView>();
            CreateMap<FileCreateView, File>();
        }
    }
}