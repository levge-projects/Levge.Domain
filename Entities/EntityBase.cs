using Levge.Domain.Interfaces;

namespace Levge.Domain.Entities
{
    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; } = default!;
    }
}
