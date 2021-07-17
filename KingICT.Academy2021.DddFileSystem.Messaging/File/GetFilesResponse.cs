using System.Collections.Generic;

namespace KingICT.Academy2021.DddFileSystem.Messaging.File
{
    public class GetFilesResponse : ResponseBase<GetFilesRequest>
    {
        public IEnumerable<FileView> Files { get; set; }
    }
}
