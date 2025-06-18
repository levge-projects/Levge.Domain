using Levge.Domain.Interfaces;

namespace Levge.Domain.Entities
{
    /// <summary>
    /// Represents the base entity with a generic identifier.
    /// </summary>
    /// <typeparam name="TKey">Type of the entity identifier.</typeparam>
    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public TKey Id { get; set; } = default!;
    }
}
