using Levge.Domain.Interfaces;

namespace Levge.Domain.Entities
{
    public abstract class AuditableEntity<TKey> : EntityBase<TKey>, IAuditable<TKey>, ISoftDeletable<TKey> where TKey : struct
    {
        public DateTime CreatedAt { get; set; }
        public TKey CreatedByUserId { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public Nullable<TKey> UpdatedByUserId { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Nullable<TKey> DeletedByUserId { get; set; }
    }
}
