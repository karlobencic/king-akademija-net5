using System.Collections.Generic;

namespace KingICT.Academy2021.DddFileSystem.Messaging.File
{
    public class SearchFilesResponse : ResponseBase<SearchFilesRequest>
    {
        public IEnumerable<FileView> Files { get; set; }
    }
}
