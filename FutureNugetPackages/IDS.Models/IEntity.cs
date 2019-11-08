using System;

namespace IDS.Models
{
    public interface IEntity
    {
    }

    public interface IEntity<TId> : IEntity
        where TId : IEquatable<TId>
    {
        TId Id { get; }
    }
}
