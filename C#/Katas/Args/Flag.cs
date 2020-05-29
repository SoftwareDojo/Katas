
namespace Katas.Args
{
    public interface IFlag
    {
        string Name { get; }
        object DefaultValue { get; }
    }

    public sealed class Flag<T> : IFlag
    {
        private readonly T _default;

        public Flag(string name, T defaultValue)
        {
            Name = name.ToLower();
            _default = defaultValue;
        }

        public string Name { get; }

        public object DefaultValue => _default;
    }
}