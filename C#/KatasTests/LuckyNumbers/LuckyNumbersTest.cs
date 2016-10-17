using Xunit;

namespace KatasTests.LuckyNumbers
{
    public class LuckyNumbersTest
    {
        [Theory]
        [InlineData(-1, "")]
        [InlineData(0, "")]
        [InlineData(1, "1")]
        [InlineData(10, "1,3,7,9")]
        [InlineData(30, "1,3,7,9,13,15,21,25")]
        [InlineData(100, "1,3,7,9,13,15,21,25,31,33,37,43,49,51,63,67,69,73,75,79,87,93,99")]
        public void GetLuckyNumbersTest(int value, string expected)
        {
            // arrange
            var lucky = new Katas.LuckyNumbers.LuckyNumbers();

            // act
            string actual = lucky.GetLuckyNumbers(value);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, "")]
        [InlineData(0, "")]
        [InlineData(1, "")]
        [InlineData(10, "3,7")]
        [InlineData(30, "3,7,13")]
        [InlineData(100, "3,7,13,31,37,43,67,73,79")]
        public void GetLuckyPrimeNumbersTest(int value, string expected)
        {
            // arrange
            var lucky = new Katas.LuckyNumbers.LuckyNumbers();

            // act
            string actual = lucky.GetLuckyPrimeNumbers(value);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
