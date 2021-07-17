using System.Collections.Generic;
using AutoMapper;
using KingICT.Academy2021.DddFileSystem.Messaging.Folder;
using KingICT.Academy2021.DddFileSystem.Model;

namespace KingICT.Academy2021.DddFileSystem.Service.Mapping
{
    public static class FolderMapper
    {
        #region Model => View

        public static FolderView MapToView(this Folder model, IMapper mapper)
        {
            return mapper.Map<Folder, FolderView>(model);
        }

        public static IEnumerable<FolderView> MapToView(this IEnumerable<Folder> model, IMapper mapper)
        {
            return mapper.Map<IEnumerable<Folder>, IEnumerable<FolderView>>(model);
        }

        #endregion

        #region View => Model

        public static Folder MapToModel(this FolderCreateView view, IMapper mapper)
        {
            return mapper.Map<FolderCreateView, Folder>(view);
        }

        #endregion
    }
}
