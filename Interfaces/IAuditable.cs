namespace Levge.Domain.Interfaces
{
    public interface IAuditable<TKey> : IEntity<TKey> where TKey : struct
    {
        DateTime CreatedAt { get; set; }
        TKey CreatedByUserId { get; set; }

        DateTime? UpdatedAt { get; set; }
        Nullable<TKey> UpdatedByUserId { get; set; }
    }
}
