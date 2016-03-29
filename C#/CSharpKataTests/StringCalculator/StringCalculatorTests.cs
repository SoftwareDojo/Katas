using NUnit.Framework;

namespace CSharpKataTests.StringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("", 0)]
        [TestCase("dgdgdg", 0)]
        [TestCase(",", 0)]
        [TestCase("15", 15)]
        [TestCase("1,2", 3)]
        [TestCase("1,  ,2", 3)]
        [TestCase("1gggd,2", 2)]
        [TestCase("asdad1,fgdgf,8", 8)]
        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4,5,6,7,8,9", 45)]
        public void TestAddWithCommas(string value, int expected)
        {
            // arrange
            var calc = new CSharpKatas.StringCalculator.StringCalculator();

            // act
            int actual = calc.Add(value, ',');

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1#2", 3)]
        [TestCase("1#  #2", 3)]
        [TestCase("1gggd#2", 2)]
        [TestCase("1,dad1#fgdgf#8", 8)]
        [TestCase("1#2#3", 6)]
        [TestCase("1#2#3#4#5#6#7#8#9", 45)]
        public void TestAddWithOtherSeperator(string value, int expected)
        {
            // arrange
            var calc = new CSharpKatas.StringCalculator.StringCalculator();

            // act
            int actual = calc.Add(value, '#');

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
