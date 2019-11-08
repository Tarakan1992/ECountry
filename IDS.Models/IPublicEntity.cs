namespace IDS.Models
{
    public interface IPublicEntity<TPublicId> : IEntity
    {
        TPublicId PublicId { get; }
    }
}
