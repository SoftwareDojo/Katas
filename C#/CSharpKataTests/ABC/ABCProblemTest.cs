using System.Collections.Generic;
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

        [TestCase("", true)]
        [TestCase("ABC", true)]
        [TestCase("baRk", true)]
        [TestCase("booK", false)]
        [TestCase("treat", false)]
        public void CheckWord_with_custom_blocks(string value, bool expected)
        {
            // arrange
            var blocks = new List<string>
            {
                "a", "b", "c",
                "d", "e", "f",
                "g", "h", "i",
                "j", "k", "l",
                "m", "n", "o",
                "p", "q", "r",
                "s", "t", "u",
                "v", "w", "x",
                "y", "z"
            };
            var abc = new ABCProblem(blocks);

            // act
            bool actual = abc.CheckWord(value);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
