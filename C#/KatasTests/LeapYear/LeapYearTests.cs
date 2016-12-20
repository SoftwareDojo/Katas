using Xunit;

namespace KatasTests.LeapYear
{
    public class LeapYearTests
    {
        [Theory]
        [InlineData(2013, false)]
        [InlineData(2001, false)]
        [InlineData(1996, true)]
        [InlineData(1992, true)]
        public void IsLeapYearTest(int value, bool expected)
        {
            //arrange
            //act
            var actual = new Katas.LeapYear.LeapYear().IsLeapYear(value);
            //assert
            Assert.Equal(expected, actual);
        }
    }
}
