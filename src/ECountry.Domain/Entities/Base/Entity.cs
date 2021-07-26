namespace ECountry.Domain.Entities.Base
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }

    public abstract class Entity : IEntity<int>
    {
        public int Id { get; }
    }
}
