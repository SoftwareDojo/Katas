using Xunit;

namespace KatasTests.LeapYear
{
    public class LeapYearTests
    {
        [Theory]
        [InlineData(2013, false)]
        [InlineData(2001, false)]
        [InlineData(2000, true)]
        [InlineData(1999, false)]
        [InlineData(1996, true)]
        [InlineData(1992, true)]
        [InlineData(1900, false)]
        [InlineData(1800, false)]
        [InlineData(1600, true)]
        [InlineData(2400, true)]

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
