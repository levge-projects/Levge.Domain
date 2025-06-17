namespace Levge.Domain.Interfaces
{
    public interface ISoftDeletable<TKey> where TKey : struct
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedAt { get; set; }
        Nullable<TKey> DeletedByUserId { get; set; }
    }
}
