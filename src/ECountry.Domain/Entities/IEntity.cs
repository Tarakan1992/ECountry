namespace ECountry.Domain.Entities
{
    public interface IEntity : IEntity<int>
    {
    }

    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; }
    }
}
