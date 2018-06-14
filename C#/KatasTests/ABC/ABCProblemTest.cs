using System.Collections.Generic;
using Xunit;

namespace KatasTests.ABC
{
    public class ABCProblemTest
    {
        [Theory]
        [InlineData("", true)]
        [InlineData("A", true)]
        [InlineData("baRk", true)]
        [InlineData("booK", false)]
        [InlineData("treat", true)]
        [InlineData("COMMON", false)]
        [InlineData("squad", true)]
        [InlineData("Confused", true)]
        public void WordIsPossible(string value, bool expected)
        {
            // arrange
            var abc = new Katas.ABC.ABCProblem();

            // act
            var actual = abc.IsPossible(value);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", true)]
        [InlineData("ABC", true)]
        [InlineData("baRk", true)]
        [InlineData("booK", false)]
        [InlineData("treat", false)]
        public void WordIsPossible_with_custom_blocks(string value, bool expected)
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
            var abc = new Katas.ABC.ABCProblem(blocks);

            // act
            var actual = abc.IsPossible(value);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
