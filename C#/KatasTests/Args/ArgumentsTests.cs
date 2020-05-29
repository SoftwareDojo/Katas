using System.Collections.Generic;
using System.Linq;

using Katas.Args;
using Xunit;

namespace KatasTests.Args
{
    public class ArgumentsTests
    {
        private const string _debug = "debug";
        private const string _build = "build";
        private const string _target = "target";
        private const string _projectFile = "ProjectFile";
        private const string _version = "version";
        private const string _cpuCount = "CpuCount";
        private const string _flagIdentifier = Arguments._flagIdentifier;
        private const string _valueIdentifier = Arguments._valueIdentifier;

        [Fact]
        public void If_arguments_are_null_return_default_flag_values()
        {
            // act
            var arguments = new Arguments(new List<IFlag> { new Flag<bool>(_debug, false) });
            arguments.Read(null);

            // assert
            Assert.False(arguments.GetValue<bool>(_debug));
        }

        [Fact]
        public void If_arguments_are_empty_return_default_flag_values()
        {
            // act
            var arguments = new Arguments(new List<IFlag> { new Flag<bool>(_debug, false) });
            arguments.Read(System.Array.Empty<string>());

            // assert
            Assert.False(arguments.GetValue<bool>(_debug));
        }

        [Fact]
        public void If_arguments_are_unknown_return_default_type_values()
        {
            // act
            string unknownFlag = "test";
            var arguments = new Arguments(new List<IFlag> { new Flag<bool>(_debug, false) });
            arguments.Read(new[] { _flagIdentifier + unknownFlag });

            // assert
            Assert.False(arguments.GetValue<bool>(unknownFlag));
            Assert.Null(arguments.GetValue<string>(unknownFlag));
            Assert.Equal(0, arguments.GetValue<int>(unknownFlag));
        }

        [Fact]
        public void if_argument_identifier_is_unknown_return_default_flag_value()
        {
            // act
            string unknownFlagIdentifier = "#";
            var arguments = new Arguments(new List<IFlag> { new Flag<bool>(_debug, true) });
            arguments.Read(new[] { unknownFlagIdentifier + _debug });

            // assert
            Assert.True(arguments.GetValue<bool>(_debug));
        }

        [Fact]
        public void Read_a_single_boolean_flag()
        {
            // act
            var flagNames = new List<string> { _debug };
            var arguments = CreateArgumentsAndRead(flagNames, new List<bool> { false }, new List<bool>());

            // assert
            AssertArgumentValues(arguments, flagNames, new List<bool>());
        }

        [Fact]
        public void Read_a_single_boolean_flag_and_value()
        {
            // act
            var flagNames = new List<string> { _debug };
            var argValues = new List<bool> { true };
            var arguments = CreateArgumentsAndRead(flagNames, new List<bool> { false }, argValues);

            // assert
            AssertArgumentValues(arguments, flagNames, argValues);
        }

        [Fact]
        public void Read_multiple_boolean_flags()
        {
            // act
            var flagNames = new List<string> { _debug, _build };
            var arguments = CreateArgumentsAndRead(flagNames, new List<bool> { false, false }, new List<bool>());

            // assert
            AssertArgumentValues(arguments, flagNames, new List<bool>());
        }

        [Fact]
        public void Read_multiple_boolean_flags_and_values()
        {
            // act
            var flagNames = new List<string> { _debug, _build };
            var argValues = new List<bool> { true, true };
            var arguments = CreateArgumentsAndRead(flagNames, new List<bool> { false, false }, argValues);

            // assert
            AssertArgumentValues(arguments, flagNames, argValues);
        }

        [Fact]
        public void Read_a_single_string_flag_and_value()
        {
            var flagNames = new List<string> { _target };
            var argValues = new List<string> { "rebuild" };
            var arguments = CreateArgumentsAndRead(flagNames, new List<string> { string.Empty }, argValues);

            // assert
            AssertArgumentValues(arguments, flagNames, argValues);
        }

        [Fact]
        public void Read_multiple_string_flags_and_values()
        {
            var flagNames = new List<string> { _target, _projectFile };
            var argValues = new List<string> { "rebuild", "Katas.proj" };
            var arguments = CreateArgumentsAndRead(flagNames, new List<string> { string.Empty, string.Empty }, argValues);

            // assert
            AssertArgumentValues(arguments, flagNames, argValues);
        }

        [Fact]
        public void Read_a_single_int_flag_and_value()
        {
            // act
            var flagNames = new List<string> { _version };
            var argValues = new List<int> { 999 };
            var arguments = CreateArgumentsAndRead(flagNames, new List<int> { 0 }, argValues);

            // assert
            AssertArgumentValues(arguments, flagNames, argValues);
        }

        [Fact]
        public void Read_multiple_int_flags_and_values()
        {
            // act
            var flagNames = new List<string> { _version, _cpuCount };
            var argValues = new List<int> { 999, 2 };
            var arguments = CreateArgumentsAndRead(flagNames, new List<int> { 0, 1 }, argValues);

            // assert
            AssertArgumentValues(arguments, flagNames, argValues);
        }

        private Arguments CreateArgumentsAndRead<T>(IList<string> flagNames, IList<T> flagDefaultValues, IList<T> argValues)
        {
            var flags = new List<Flag<T>>();
            var args = new List<string>();

            for (int i = 0; i < flagNames.Count; i++)
            {
                flags.Add(new Flag<T>(flagNames[i], flagDefaultValues[i]));

                var arg = _flagIdentifier + flagNames[i];
                if (argValues.Any()) arg += _valueIdentifier + argValues[i];
                args.Add(arg);
            }

            var arguments = new Arguments(flags);
            arguments.Read(args.ToArray());

            return arguments;
        }

        private void AssertArgumentValues<T>(Arguments arguments, IList<string> flagNames, IList<T> argValues)
        {
            for (int i = 0; i < flagNames.Count; i++)
            {
                if (argValues.Any())
                {
                    Assert.Equal(argValues[i], arguments.GetValue<T>(flagNames[i]));
                }
                else
                {
                    Assert.NotEqual(default, arguments.GetValue<T>(flagNames[i]));
                }
            }
        }
    }
}
