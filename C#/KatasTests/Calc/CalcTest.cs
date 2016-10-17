using Xunit;

namespace KatasTests.Calc
{
    public class CalcTest
    {
        [Theory]
        [InlineData("1 + 1", 2)]
        [InlineData("1 + 1 + 2", 4)]
        [InlineData("1 + 2 * 3", 7)]
        [InlineData("1 + 2 * 3 * 4", 25)]
        //[InlineData("1 + 2 * 3 + 1", 10)]
        public void AdditionAndMultiplication(string value, double expected)
        {
            // arrange
            var calc = new Katas.Calc.Calc();

            // act
            string actualText;
            double actual = calc.Evaluate(value, out actualText);

            // assert
            Assert.Equal(expected, actual);
            Assert.Equal(value, actualText);
        }

        [Theory]
        [InlineData("1 - 1", 0)]
        //[InlineData("5 - 1 - 2", 2)]
        //[InlineData("12 - 3 / 3", 11)]
        public void SubtractioAndDivision(string value, double expected)
        {
            // arrange
            var calc = new Katas.Calc.Calc();

            // act
            string actualText;
            double actual = calc.Evaluate(value, out actualText);

            // assert
            Assert.Equal(expected, actual);
            Assert.Equal(value, actualText);
        }
    }
}
