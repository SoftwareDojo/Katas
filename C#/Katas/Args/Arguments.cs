using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas.Args
{
    public class Arguments
    {
        public const string FlagIdentifier = "-";
        public const string ValueIdentifier = ":";
        private readonly Dictionary<string, string> _flagValues = new Dictionary<string, string>();

        public IDictionary<string, IFlag> Flags { get; }

        public Arguments(IEnumerable<IFlag> flags)
        {
            Flags = flags.ToDictionary(a => a.Name);
        }

        public T GetValue<T>(string name)
        {
            var flagName = name.ToLower();
            if (_flagValues.ContainsKey(flagName)) return (T)Convert.ChangeType(_flagValues[flagName], typeof(T));
            if (Flags.ContainsKey(flagName)) return (T)Convert.ChangeType(Flags[flagName].DefaultValue, typeof(T));

            return default;
        }

        public void Read(string[] args)
        {
            _flagValues.Clear();

            if (args == null || !args.Any()) return;

            ReadFlagsAndValues(args);
        }

        private void ReadFlagsAndValues(string[] args)
        {
            foreach (var arg in args)
            {
                if (!arg.StartsWith(FlagIdentifier)) continue;

                var hasValue = HasValue(arg, out var valuePos);
                if (!HasFlag(arg, valuePos, out var flag)) continue;

                if (hasValue)
                {
                    AddFlagValue(flag, arg.Substring(valuePos + 1));
                    continue;
                }

                AddDefaultBooleanFlagValue(flag);
            }
        }

        private bool HasValue(string arg, out int valuePos)
        {
            valuePos = arg.IndexOf(ValueIdentifier, StringComparison.CurrentCulture);
            if (valuePos >= 0) return true;

            valuePos = arg.Length;
            return false;
        }

        private bool HasFlag(string arg, int valuePos, out string flag)
        {
            flag = arg.Substring(1, valuePos - 1).ToLower();
            return Flags.ContainsKey(flag);
        }

        private void AddFlagValue(string flag, string value)
        {
            _flagValues.Add(flag, value);
        }

        private void AddDefaultBooleanFlagValue(string flag)
        {
            _flagValues.Add(flag, "true");
        }
    }
}
