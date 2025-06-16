using Levge.Domain.Interfaces;

namespace Levge.Domain.Entities
{
    public abstract class AuditableEntity<TKey> : EntityBase<TKey>, IAuditable<TKey>, ISoftDeletable<TKey>
    {
        public DateTime CreatedAt { get; set; }
        public TKey? CreatedByUserId { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public TKey? UpdatedByUserId { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public TKey? DeletedByUserId { get; set; }
    }
}
