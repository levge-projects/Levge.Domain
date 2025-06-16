using Levge.Exceptions;

namespace Levge.Domain.Enums
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; }
        public int Value { get; }

        protected Enumeration(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public override string ToString() => Name;

        public int CompareTo(object? other)
            => other is Enumeration otherEnum ? Value.CompareTo(otherEnum.Value) : -1;

        public override bool Equals(object? obj)
        {
            if (obj is not Enumeration other) return false;
            return GetType().Equals(other.GetType()) && Value.Equals(other.Value);
        }

        public override int GetHashCode() => HashCode.Combine(GetType(), Value);

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            return typeof(T).GetFields(System.Reflection.BindingFlags.Public |
                                       System.Reflection.BindingFlags.Static |
                                       System.Reflection.BindingFlags.DeclaredOnly)
                            .Select(f => f.GetValue(null))
                            .Cast<T>();
        }

        public static T FromValue<T>(int value) where T : Enumeration
        {
            return GetAll<T>().FirstOrDefault(e => e.Value == value)
                   ?? throw new LevgeValidationException(nameof(value), $"Invalid value '{value}' for {typeof(T).Name}");
        }

        public static T FromName<T>(string name) where T : Enumeration
        {
            return GetAll<T>().FirstOrDefault(e => e.Name == name)
                   ?? throw new LevgeValidationException(nameof(name), $"Invalid name '{name}' for {typeof(T).Name}");
        }
    }
}
