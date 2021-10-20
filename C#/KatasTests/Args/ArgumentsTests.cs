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
        private readonly bool[] _emptValues = System.Array.Empty<bool>();

        [Fact]
        public void If_arguments_are_null_return_default_flag_values()
        {
            // act
            var arguments = new Arguments(new IFlag[] { new Flag<bool>(_debug, false) });
            arguments.Read(null);

            // assert
            Assert.False(arguments.GetValue<bool>(_debug));
        }

        [Fact]
        public void If_arguments_are_empty_return_default_flag_values()
        {
            // act
            var arguments = new Arguments(new IFlag[] { new Flag<bool>(_debug, false) });
            arguments.Read(System.Array.Empty<string>());

            // assert
            Assert.False(arguments.GetValue<bool>(_debug));
        }

        [Fact]
        public void If_arguments_are_unknown_return_default_type_values()
        {
            // act
            string unknownFlag = "test";
            var arguments = new Arguments(new IFlag[] { new Flag<bool>(_debug, false) });
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
            var arguments = new Arguments(new IFlag[] { new Flag<bool>(_debug, true) });
            arguments.Read(new[] { unknownFlagIdentifier + _debug });

            // assert
            Assert.True(arguments.GetValue<bool>(_debug));
        }

        [Fact]
        public void Read_a_single_boolean_flag()
        {
            // act
            var flagNames = new[] { _debug };
            var arguments = CreateArgumentsAndRead(flagNames, new[] { false }, _emptValues);

            // assert
            AssertArgumentValues(arguments, flagNames, _emptValues);
        }

        [Fact]
        public void Read_a_single_boolean_flag_and_value()
        {
            // act
            var flagNames = new[] { _debug };
            var argValues = new[] { true };
            var arguments = CreateArgumentsAndRead(flagNames, new[] { false }, argValues);

            // assert
            AssertArgumentValues(arguments, flagNames, argValues);
        }

        [Fact]
        public void Read_multiple_boolean_flags()
        {
            // act
            var flagNames = new[] { _debug, _build };
            var arguments = CreateArgumentsAndRead(flagNames, new[] { false, false }, _emptValues);

            // assert
            AssertArgumentValues(arguments, flagNames, _emptValues);
        }

        [Fact]
        public void Read_multiple_boolean_flags_and_values()
        {
            // act
            var flagNames = new[] { _debug, _build };
            var argValues = new[] { true, true };
            var arguments = CreateArgumentsAndRead(flagNames, new[] { false, false }, argValues);

            // assert
            AssertArgumentValues(arguments, flagNames, argValues);
        }

        [Fact]
        public void Read_a_single_string_flag_and_value()
        {
            var flagNames = new[] { _target };
            var argValues = new[] { "rebuild" };
            var arguments = CreateArgumentsAndRead(flagNames, new[] { string.Empty }, argValues);

            // assert
            AssertArgumentValues(arguments, flagNames, argValues);
        }

        [Fact]
        public void Read_multiple_string_flags_and_values()
        {
            var flagNames = new[] { _target, _projectFile };
            var argValues = new[] { "rebuild", "Katas.proj" };
            var arguments = CreateArgumentsAndRead(flagNames, new[] { string.Empty, string.Empty }, argValues);

            // assert
            AssertArgumentValues(arguments, flagNames, argValues);
        }

        [Fact]
        public void Read_a_single_int_flag_and_value()
        {
            // act
            var flagNames = new[] { _version };
            var argValues = new[] { 999 };
            var arguments = CreateArgumentsAndRead(flagNames, new[] { 0 }, argValues);

            // assert
            AssertArgumentValues(arguments, flagNames, argValues);
        }

        [Fact]
        public void Read_multiple_int_flags_and_values()
        {
            // act
            var flagNames = new[] { _version, _cpuCount };
            var argValues = new[] { 999, 2 };
            var arguments = CreateArgumentsAndRead(flagNames, new[] { 0, 1 }, argValues);

            // assert
            AssertArgumentValues(arguments, flagNames, argValues);
        }

        private Arguments CreateArgumentsAndRead<T>(string[] flagNames, T[] flagDefaultValues, T[] argValues)
        {
            var argumentCount = flagNames.Length;
            var flags = new Flag<T>[argumentCount];
            var args = new string[argumentCount];

            for (int i = 0; i < argumentCount; i++)
            {
                flags[i] = new Flag<T>(flagNames[i], flagDefaultValues[i]);

                var arg = _flagIdentifier + flagNames[i];
                if (argValues.Any()) arg += _valueIdentifier + argValues[i];
                args[i] = arg;
            }

            var arguments = new Arguments(flags);
            arguments.Read(args.ToArray());

            return arguments;
        }

        private void AssertArgumentValues<T>(Arguments arguments, string[] flagNames, T[] argValues)
        {
            for (int i = 0; i < flagNames.Length; i++)
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
