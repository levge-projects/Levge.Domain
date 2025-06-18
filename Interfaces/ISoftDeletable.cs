namespace Levge.Domain.Interfaces
{
    /// <summary>
    /// Defines soft delete properties for an entity.
    /// </summary>
    /// <typeparam name="TKey">Type of the entity identifier.</typeparam>
    public interface ISoftDeletable<TKey> where TKey : struct
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is soft deleted.
        /// </summary>
        bool IsDeleted { get; set; }
        
        /// <summary>
        /// Gets or sets the date and time when the entity was soft deleted.
        /// </summary>
        DateTime? DeletedAt { get; set; }
        
        /// <summary>
        /// Gets or sets the identifier of the user who soft deleted the entity.
        /// </summary>
        Nullable<TKey> DeletedByUserId { get; set; }
    }
}
