using Katas;
using Xunit;

namespace KatasTests
{
    public class CalcStatsTests
    {
        [Fact]
        public void GetMinValue()
        {
            Assert.Equal(-2, (int)CalcStats.GetStats("Min", new[] { 1, -1, 2, -2, 6, 9, 15, -2, 92, 11 }));
        }

        [Fact]
        public void GetMaxValue()
        {
            Assert.Equal(92, (int)CalcStats.GetStats("Max", new[] { 1, -1, 2, -2, 6, 9, 15, -2, 92, 11 }));
        }

        [Fact]
        public void GetSumValue()
        {
            Assert.Equal(131, (int)CalcStats.GetStats("Sum", new[] { 1, -1, 2, -2, 6, 9, 15, -2, 92, 11 }));
        }

        [Fact]
        public void GetAverageValue()
        {
            Assert.Equal(13.1, (double)CalcStats.GetStats("Average", new[] { 1, -1, 2, -2, 6, 9, 15, -2, 92, 11 }));
        }
    }
}
