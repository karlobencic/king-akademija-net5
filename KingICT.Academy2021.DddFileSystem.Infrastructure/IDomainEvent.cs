using System;

namespace KingICT.Academy2021.DddFileSystem.Infrastructure
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
