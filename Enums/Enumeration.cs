using Levge.Exceptions;

namespace Levge.Domain.Enums
{
    /// <summary>
    /// Provides a base class for domain-driven enumeration patterns.
    /// </summary>
    public abstract class Enumeration : IComparable
    {
        /// <summary>
        /// Gets the name of the enumeration value.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gets the integer value of the enumeration.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        /// <param name="value">The integer value of the enumeration.</param>
        /// <param name="name">The name of the enumeration.</param>
        protected Enumeration(int value, string name)
        {
            Value = value;
            Name = name;
        }

        /// <inheritdoc/>
        public override string ToString() => Name;

        /// <inheritdoc/>
        public int CompareTo(object? other)
            => other is Enumeration otherEnum ? Value.CompareTo(otherEnum.Value) : -1;

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is not Enumeration other) return false;
            return GetType().Equals(other.GetType()) && Value.Equals(other.Value);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(GetType(), Value);

        /// <summary>
        /// Gets all defined values of the enumeration type.
        /// </summary>
        /// <typeparam name="T">Enumeration type.</typeparam>
        /// <returns>All defined values of the enumeration type.</returns>
        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            return typeof(T).GetFields(System.Reflection.BindingFlags.Public |
                                       System.Reflection.BindingFlags.Static |
                                       System.Reflection.BindingFlags.DeclaredOnly)
                            .Select(f => f.GetValue(null))
                            .Cast<T>();
        }

        /// <summary>
        /// Gets the enumeration value by its integer value.
        /// </summary>
        /// <typeparam name="T">Enumeration type.</typeparam>
        /// <param name="value">Integer value.</param>
        /// <returns>Enumeration value.</returns>
        /// <exception cref="LevgeValidationException">Thrown if value is not valid for the enumeration type.</exception>
        public static T FromValue<T>(int value) where T : Enumeration
        {
            return GetAll<T>().FirstOrDefault(e => e.Value == value)
                   ?? throw new LevgeValidationException(nameof(value), $"Invalid value '{value}' for {typeof(T).Name}");
        }

        /// <summary>
        /// Gets the enumeration value by its name.
        /// </summary>
        /// <typeparam name="T">Enumeration type.</typeparam>
        /// <param name="name">Name of the enumeration value.</param>
        /// <returns>Enumeration value.</returns>
        /// <exception cref="LevgeValidationException">Thrown if name is not valid for the enumeration type.</exception>
        public static T FromName<T>(string name) where T : Enumeration
        {
            return GetAll<T>().FirstOrDefault(e => e.Name == name)
                   ?? throw new LevgeValidationException(nameof(name), $"Invalid name '{name}' for {typeof(T).Name}");
        }

        /// <summary>
        /// Determines whether this instance is one of the specified values.
        /// </summary>
        /// <param name="values">Enumeration values to check.</param>
        /// <returns>True if this instance is one of the specified values; otherwise, false.</returns>
        public bool IsOneOf(params Enumeration[] values)
        {
            return values.Any(v => Equals(v));
        }
    }
}
