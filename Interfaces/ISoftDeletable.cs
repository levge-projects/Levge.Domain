namespace Levge.Domain.Interfaces
{
    public interface ISoftDeletable<TKey>
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedAt { get; set; }
        TKey? DeletedByUserId { get; set; }
    }
}
