using Levge.Domain.Interfaces;

namespace Levge.Domain.Entities
{
    /// <summary>
    /// Represents an auditable entity with creation, update, and soft delete tracking.
    /// </summary>
    /// <typeparam name="TKey">Type of the entity identifier.</typeparam>
    public abstract class AuditableEntity<TKey> : EntityBase<TKey>, IAuditable<TKey>, ISoftDeletable<TKey> where TKey : struct
    {
        /// <summary>
        /// Gets or sets the creation date and time of the entity.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the identifier of the user who created the entity.
        /// </summary>
        public TKey CreatedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the last update date and time of the entity.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets the identifier of the user who last updated the entity.
        /// </summary>
        public Nullable<TKey> UpdatedByUserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is soft deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the entity was soft deleted.
        /// </summary>
        public DateTime? DeletedAt { get; set; }
        /// <summary>
        /// Gets or sets the identifier of the user who soft deleted the entity.
        /// </summary>
        public Nullable<TKey> DeletedByUserId { get; set; }
    }
}
