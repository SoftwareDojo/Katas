using NUnit.Framework;

namespace CSharpKataTests.OddEven
{
    [TestFixture]
    public class OddEvenTest
    {
        [TestCase(1, "Odd")]
        [TestCase(2, "Even")]
        [TestCase(3, "3")]
        [TestCase(4, "Even")]
        [TestCase(5, "5")]
        [TestCase(6, "Even")]
        [TestCase(7, "7")]
        [TestCase(8, "Even")]
        [TestCase(9, "Odd")]
        [TestCase(10, "Even")]
        public void SingleOddEvenTest(int number, string expected)
        {
            // arrange
            var oddEven = new CSharpKatas.OddEven.OddEven();

            // act
            string actual = oddEven.Convert(number);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MultipleOddEvenTest()
        {
            // arrange
            var oddEven = new CSharpKatas.OddEven.OddEven();

            // act
            string actual = oddEven.ConvertRange(1, 10);

            // assert
            string expected = "Odd Even 3 Even 5 Even 7 Even Odd Even";
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "Odd")]
        [TestCase(2, "Even")]
        [TestCase(3, "3")]
        [TestCase(4, "Even")]
        [TestCase(5, "5")]
        [TestCase(6, "Even")]
        [TestCase(7, "7")]
        [TestCase(8, "Even")]
        [TestCase(9, "Odd")]
        [TestCase(10, "Even")]
        public void StringOddEvenTest(int number, string expected)
        {
            // arrange
            var oddEven = new CSharpKatas.OddEven.OddEven();

            // act
            string actual = oddEven.ConvertWithString(number);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
