using Xunit;

namespace KatasTests.FizzBuzz
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(0, "")]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "fizz")]
        [InlineData(4, "4")]
        [InlineData(5, "buzz")]
        [InlineData(6, "fizz")]
        [InlineData(10, "buzz")]
        [InlineData(15, "fizzbuzz")]
        public void SimpleFizzBuzz(int value, string expected)
        {
            // arrange
            var target = new Katas.FizzBuzz.FizzBuzz();

            // act
            string actual = target.DoFizzBuzz((uint)value);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, "")]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "fizz")]
        [InlineData(4, "4")]
        [InlineData(5, "buzz")]
        [InlineData(6, "fizz")]
        [InlineData(10, "buzz")]
        [InlineData(13, "fizz")]
        [InlineData(15, "fizzbuzz")]
        [InlineData(25, "buzz")]
        [InlineData(35, "fizzbuzz")]
        [InlineData(52, "buzz")]
        [InlineData(53, "fizzbuzz")]
        public void ExtendedFizzBuzz(int value, string expected)
        {
            // arrange
            var target = new Katas.FizzBuzz.FizzBuzz();

            // act
            string actual = target.DoFizzBuzzExtended((uint)value);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
