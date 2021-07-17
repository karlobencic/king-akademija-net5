using System.Collections.Generic;

namespace KingICT.Academy2021.DddFileSystem.Messaging.Folder
{
    public class GetFoldersResponse : ResponseBase<GetFoldersRequest>
    {
        public IEnumerable<FolderView> Folders { get; set; }
    }
}
