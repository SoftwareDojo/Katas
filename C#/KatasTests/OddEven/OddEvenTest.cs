using Xunit;

namespace KatasTests.OddEven
{
    public class OddEvenTest
    {
        [Theory]
        [InlineData(1, "Odd")]
        [InlineData(2, "Even")]
        [InlineData(3, "3")]
        [InlineData(4, "Even")]
        [InlineData(5, "5")]
        [InlineData(6, "Even")]
        [InlineData(7, "7")]
        [InlineData(8, "Even")]
        [InlineData(9, "Odd")]
        [InlineData(10, "Even")]
        public void SingleOddEvenTest(int number, string expected)
        {
            // arrange
            var oddEven = new Katas.OddEven.OddEven();

            // act
            string actual = oddEven.Convert(number);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultipleOddEvenTest()
        {
            // arrange
            var oddEven = new Katas.OddEven.OddEven();

            // act
            string actual = oddEven.ConvertRange(1, 10);

            // assert
            string expected = "Odd Even 3 Even 5 Even 7 Even Odd Even";
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, "Odd")]
        [InlineData(2, "Even")]
        [InlineData(3, "3")]
        [InlineData(4, "Even")]
        [InlineData(5, "5")]
        [InlineData(6, "Even")]
        [InlineData(7, "7")]
        [InlineData(8, "Even")]
        [InlineData(9, "Odd")]
        [InlineData(10, "Even")]
        public void StringOddEvenTest(int number, string expected)
        {
            // arrange
            var oddEven = new Katas.OddEven.OddEven();

            // act
            string actual = oddEven.ConvertWithString(number);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
