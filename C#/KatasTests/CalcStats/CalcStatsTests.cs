using Xunit;

namespace KatasTests.CalcStats
{
    public class CalcStatsTests
    {
        [Fact]
        public void GetMinValue()
        {
            //arrange
            //act
            var actual = new Katas.CalcStats.CalcStats().GetStats("Min", new[] { 1, -1, 2, -2, 6, 9, 15, -2, 92, 11 });
            //assert
            Assert.Equal("-2", actual);
        }

        [Fact]
        public void GetMaxValue()
        {
            //arrange
            //act
            var actual = new Katas.CalcStats.CalcStats().GetStats("Max", new[] { 1, -1, 2, -2, 6, 9, 15, -2, 92, 11 });
            //assert
            Assert.Equal("92", actual);
        }

        [Fact]
        public void GetSumValue()
        {
            //arrange
            //act
            var actual = new Katas.CalcStats.CalcStats().GetStats("Sum", new[] { 1, -1, 2, -2, 6, 9, 15, -2, 92, 11 });
            //assert
            Assert.Equal("131", actual);
        }

        [Fact]
        public void GetAverageValue()
        {
            //arrange
            //act
            var actual = new Katas.CalcStats.CalcStats().GetStats("Average", new[] { 1, -1, 2, -2, 6, 9, 15, -2, 92, 11 });
            //assert
            Assert.Equal("13.1", actual);
        }
    }
}
