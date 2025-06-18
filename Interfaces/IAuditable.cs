namespace Levge.Domain.Interfaces
{
    /// <summary>
    /// Defines auditing properties for an entity.
    /// </summary>
    /// <typeparam name="TKey">Type of the entity identifier.</typeparam>
    public interface IAuditable<TKey> : IEntity<TKey> where TKey : struct
    {
        /// <summary>
        /// Gets or sets the creation date and time of the entity.
        /// </summary>
        DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Gets or sets the identifier of the user who created the entity.
        /// </summary>
        TKey CreatedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the last update date and time of the entity.
        /// </summary>
        DateTime? UpdatedAt { get; set; }
        
        /// <summary>
        /// Gets or sets the identifier of the user who last updated the entity.
        /// </summary>
        Nullable<TKey> UpdatedByUserId { get; set; }
    }
}
