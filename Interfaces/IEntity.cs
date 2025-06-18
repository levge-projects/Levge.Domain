namespace Levge.Domain.Interfaces
{
    /// <summary>
    /// Defines the base contract for an entity with a generic identifier.
    /// </summary>
    /// <typeparam name="TKey">Type of the entity identifier.</typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        TKey Id { get; set; }
    }
}
