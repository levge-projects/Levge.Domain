namespace Levge.Domain.Interfaces
{
    public interface IAuditable<TKey> : IEntity<TKey>
    {
        DateTime CreatedAt { get; set; }
        TKey? CreatedByUserId { get; set; }

        DateTime? UpdatedAt { get; set; }
        TKey? UpdatedByUserId { get; set; }
    }
}
