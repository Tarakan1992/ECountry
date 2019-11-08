namespace IDS.Models
{
    public abstract class PublicEntity<TPublicId> : Entity, IPublicEntity<TPublicId>
    {
        public TPublicId PublicId { get; private set; }
    }

    public abstract class PublicEntity : PublicEntity<string> { }
}
