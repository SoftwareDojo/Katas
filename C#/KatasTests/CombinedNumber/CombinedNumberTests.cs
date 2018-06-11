using Xunit;

namespace KatasTests.CombinedNumber
{
    public class CombinedNumberTests
    {
        [Fact]
        public void Combine_Null()
        {
            // act
            var actual = new Katas.CombinedNumber.CombinedNumber().Combine(null);
            // assert
            Assert.Empty(actual);
        }

        [Fact]
        public void Combine_Empty()
        {
            // act
            var actual = new Katas.CombinedNumber.CombinedNumber().Combine(new int[] { });
            // assert
            Assert.Empty(actual);
        }

        [Fact]
        public void Combine_One_Digit_Numbers()
        {
            // act
            var actual = new Katas.CombinedNumber.CombinedNumber().Combine(new [] {5, 2, 1, 9});
            // assert
            Assert.Equal("9521", actual);
        }

        [Fact]
        public void Combine_Two_Digit_Number()
        {
            // act
            var actual = new Katas.CombinedNumber.CombinedNumber().Combine(new [] {50, 2, 1, 9});
            // assert
            Assert.Equal("95021", actual);
        }

        [Fact]
        public void Combine_Two_Digit_Numbers()
        {
            // act
            var actual = new Katas.CombinedNumber.CombinedNumber().Combine(new [] {5, 50, 56});
            // assert
            Assert.Equal("56550", actual);
        }

        [Fact]
        public void Combine_Multi_Digit_Numbers()
        {
            // act
            var actual = new Katas.CombinedNumber.CombinedNumber().Combine(new [] {420, 42, 423});
            // assert
            Assert.Equal("42423420", actual);
        }

        [Theory]
        [InlineData("0", new [] { 0 })]
        [InlineData("12345", new [] { 1,2,3,4,5 })]
        public void SplitNumber(string number, int[] expected)
        {
            // act
            var actual = new Katas.CombinedNumber.CombinedNumber().SplitNumber(number);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1,2,1)]
        [InlineData(2,1,-1)]
        [InlineData(1,1,0)]
        [InlineData(5,50,-1)]
        [InlineData(50,5,1)]
        [InlineData(56,55,-1)]
        [InlineData(42,423,-1)]
        public void CompareNumbersByLengthAndValue(int x, int y, int expected)
        {
            // act
            var actual = new Katas.CombinedNumber.CombinedNumber().CompareNumbersByLengthAndValue(x, y);
            // assert
            Assert.Equal(expected, actual);
        }
    }
}
