using NUnit.Framework;

namespace CSharpKataTests.Calc
{
    [TestFixture]
    public class CalcTest
    {
        [TestCase("1 + 1", 2)]
        [TestCase("1 + 1 + 2", 4)]
        [TestCase("1 + 2 * 3", 7)]
        [TestCase("1 + 2 * 3 * 4", 25)]
        //[TestCase("1 + 2 * 3 + 1", 10)]
        public void AdditionAndMultiplication(string value, double expected)
        {
            // arrange
            var calc = new CSharpKatas.Calc.Calc();

            // act
            string actualText;
            double actual = calc.Evaluate(value, out actualText);

            // assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(value, actualText);
        }

        [TestCase("1 - 1", 0)]
        //[TestCase("5 - 1 - 2", 2)]
        //[TestCase("12 - 3 / 3", 11)]
        public void SubtractioAndDivision(string value, double expected)
        {
            // arrange
            var calc = new CSharpKatas.Calc.Calc();

            // act
            string actualText;
            double actual = calc.Evaluate(value, out actualText);

            // assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(value, actualText);
        }
    }
}
