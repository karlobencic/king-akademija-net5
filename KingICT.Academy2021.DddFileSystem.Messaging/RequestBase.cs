using System;

namespace KingICT.Academy2021.DddFileSystem.Messaging
{
    public abstract class RequestBase
    {
        public Guid RequestToken { get; set; }
    }
}
