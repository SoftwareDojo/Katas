using Katas;
using Xunit;

namespace KatasTests
{
    public class CombinedNumberTests
    {
        [Fact]
        public void Combine_Null()
        {
            Assert.Empty(CombinedNumber.Combine(null));
        }

        [Fact]
        public void Combine_Empty()
        {
            Assert.Empty(CombinedNumber.Combine(new int[] { }));
        }

        [Fact]
        public void Combine_One_Digit_Numbers()
        {
            Assert.Equal("9521", CombinedNumber.Combine(new[] { 5, 2, 1, 9 }));
        }

        [Fact]
        public void Combine_Two_Digit_Number()
        {
            Assert.Equal("95021", CombinedNumber.Combine(new[] { 50, 2, 1, 9 }));
        }

        [Fact]
        public void Combine_Two_Digit_Numbers()
        {
            Assert.Equal("56550", CombinedNumber.Combine(new[] { 5, 50, 56 }));
        }

        [Fact]
        public void Combine_Multi_Digit_Numbers()
        {
            Assert.Equal("42423420", CombinedNumber.Combine(new[] { 420, 42, 423 }));
        }

        [Theory]
        [InlineData("0", new[] { 0 })]
        [InlineData("12345", new[] { 1, 2, 3, 4, 5 })]
        public void SplitNumber(string number, int[] expected)
        {
            Assert.Equal(expected, CombinedNumber.SplitNumber(number));
        }

        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(2, 1, -1)]
        [InlineData(1, 1, 0)]
        [InlineData(5, 50, -1)]
        [InlineData(50, 5, 1)]
        [InlineData(56, 55, -1)]
        [InlineData(42, 423, -1)]
        public void CompareNumbersByLengthAndValue(int x, int y, int expected)
        {
            Assert.Equal(expected, CombinedNumber.CompareNumbersByLengthAndValue(x, y));
        }
    }
}
