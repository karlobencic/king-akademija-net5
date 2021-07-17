using System.Collections.Generic;
using AutoMapper;
using KingICT.Academy2021.DddFileSystem.Messaging.File;
using KingICT.Academy2021.DddFileSystem.Model;

namespace KingICT.Academy2021.DddFileSystem.Service.Mapping
{
    public static class FileMapper
    {
        #region Model => View

        public static FileView MapToView(this File model, IMapper mapper)
        {
            return mapper.Map<File, FileView>(model);
        }

        public static IEnumerable<FileView> MapToView(this IEnumerable<File> model, IMapper mapper)
        {
            return mapper.Map<IEnumerable<File>, IEnumerable<FileView>>(model);
        }

        #endregion

        #region View => Model

        public static File MapToModel(this FileCreateView view, IMapper mapper)
        {
            return mapper.Map<FileCreateView, File>(view);
        }

        #endregion
    }
}