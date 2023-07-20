using Katas;
using Xunit;

namespace KatasTests
{
    public class StringCalculatorTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("dgdgdg", 0)]
        [InlineData(",", 0)]
        [InlineData("15", 15)]
        [InlineData("1,2", 3)]
        [InlineData("1,  ,2", 3)]
        [InlineData("1gggd,2", 2)]
        [InlineData("asdad1,fgdgf,8", 8)]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2,3,4,5,6,7,8,9", 45)]
        public void TestAddWithCommas(string value, int expected)
        {
            Assert.Equal(expected, StringCalculator.Add(value, ','));
        }

        [Theory]
        [InlineData("1#2", 3)]
        [InlineData("1#  #2", 3)]
        [InlineData("1gggd#2", 2)]
        [InlineData("1,dad1#fgdgf#8", 8)]
        [InlineData("1#2#3", 6)]
        [InlineData("1#2#3#4#5#6#7#8#9", 45)]
        public void TestAddWithOtherSeperator(string value, int expected)
        {
            Assert.Equal(expected, StringCalculator.Add(value, '#'));
        }
    }
}
