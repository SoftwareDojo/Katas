using CSharpKatas.ABC;
using NUnit.Framework;

namespace CSharpKataTests.ABC
{
    [TestFixture]
    public class ABCProblemTest
    {
        [TestCase("", true)]
        [TestCase("A", true)]
        [TestCase("baRk", true)]
        [TestCase("booK", false)]
        [TestCase("treat", true)]
        [TestCase("COMMON", false)]
        [TestCase("squad", true)]
        [TestCase("Confused", true)]
        public void CheckWord(string value, bool expected)
        {
            // arrange
            var abc = new ABCProblem();

            // act
            bool actual = abc.CheckWord(value);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
