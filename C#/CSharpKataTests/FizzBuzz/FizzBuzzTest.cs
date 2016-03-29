using NUnit.Framework;

namespace CSharpKataTests.FizzBuzz
{
    [TestFixture]
    public class FizzBuzzTest
    {
        [TestCase(0, "")]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "fizz")]
        [TestCase(4, "4")]
        [TestCase(5, "buzz")]
        [TestCase(6, "fizz")]
        [TestCase(10, "buzz")]
        [TestCase(15, "fizzbuzz")]
        public void DoFizzBuzzTest(int value, string expected)
        {
            // arrange
            var target = new CSharpKatas.FizzBuzz.FizzBuzz();

            // act
            string actual = target.DoFizzBuzz((uint)value);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, "")]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "fizz")]
        [TestCase(4, "4")]
        [TestCase(5, "buzz")]
        [TestCase(6, "fizz")]
        [TestCase(10, "buzz")]
        [TestCase(13, "fizz")]
        [TestCase(15, "fizzbuzz")]
        [TestCase(25, "buzz")]
        [TestCase(35, "fizzbuzz")]
        [TestCase(52, "buzz")]
        [TestCase(53, "fizzbuzz")]
        public void DoFizzBuzzExtendedTest(int value, string expected)
        {
            // arrange
            var target = new CSharpKatas.FizzBuzz.FizzBuzz();

            // act
            string actual = target.DoFizzBuzzExtended((uint)value);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
