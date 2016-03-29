using NUnit.Framework;

namespace CSharpKataTests.LuckyNumbers
{
    [TestFixture]
    public class LuckyNumbersTest
    {
        [TestCase(-1, "")]
        [TestCase(0, "")]
        [TestCase(1, "1")]
        [TestCase(10, "1,3,7,9")]
        [TestCase(30, "1,3,7,9,13,15,21,25")]
        [TestCase(100, "1,3,7,9,13,15,21,25,31,33,37,43,49,51,63,67,69,73,75,79,87,93,99")]
        public void GetLuckyNumbersTest(int value, string expected)
        {
            // arrange
            var lucky = new CSharpKatas.LuckyNumbers.LuckyNumbers();

            // act
            string actual = lucky.GetLuckyNumbers(value);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, "")]
        [TestCase(0, "")]
        [TestCase(1, "")]
        [TestCase(10, "3,7")]
        [TestCase(30, "3,7,13")]
        [TestCase(100, "3,7,13,31,37,43,67,73,79")]
        public void GetLuckyPrimeNumbersTest(int value, string expected)
        {
            // arrange
            var lucky = new CSharpKatas.LuckyNumbers.LuckyNumbers();

            // act
            string actual = lucky.GetLuckyPrimeNumbers(value);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
