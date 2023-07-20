using System;
using Katas;
using Xunit;

namespace KatasTests
{
    public class BinarySearcherTests
    {
        [Fact]
        public void NullInputSearch()
        {
            Assert.Throws<ArgumentNullException>(() => BinarySearcher.Search(null, 1));
        }

        [Fact]
        public void NullInputIndexSearch()
        {
            Assert.Throws<ArgumentNullException>(() => BinarySearcher.Search(null, 0, 0, 1));
        }

        [Fact]
        public void NegativIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BinarySearcher.Search(Array.Empty<int>(), -1, 0, 0));
        }

        [Fact]
        public void NegativLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BinarySearcher.Search(Array.Empty<int>(), 0, -1, 0));
        }

        [Fact]
        public void ZeroLength()
        {
            Assert.Equal(0, BinarySearcher.Search(new int[1], 0, 0, 0));
        }

        [Fact]
        public void IndexOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BinarySearcher.Search(new int[0], 1));
        }

        [Fact]
        public void InvalidLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BinarySearcher.Search(new int[1], 0, 2, 1));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 2, 1)]
        [InlineData(0, 3, 1)]
        [InlineData(2, 4, 3)]
        [InlineData(0, int.MaxValue, int.MaxValue/2)]
        public void GetMedian(int low, int high, int expected)
        {
            Assert.Equal(expected, BinarySearcher.GetMedian(low, high));
        }

        [Theory]
        [InlineData(new [] { 0 }, 0, 0)]
        [InlineData(new[] { 1, 5, 7, 13 }, 7, 2)]
        [InlineData(new[] { 1, 5, 7, 13 }, 1, 0)]
        [InlineData(new[] { 1, 5, 7, 13 }, 13, 3)]
        [InlineData(new[] { 1, 5, 7, 13 }, 6, 0)]
        public void Search(int[] array, int value, int expected)
        {
            Assert.Equal(expected, BinarySearcher.Search(array, value));
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4 }, 2, 3, 4, 4)]
        [InlineData(new[] { 0, 1, 2, 3, 4 }, 1, 2, 2, 2)]
        [InlineData(new[] { 0, 1, 2, 3, 4 }, 1, 1, 1, 1)]
        public void SearchIndex(int[] array, int index, int length, int value, int expected)
        {
            Assert.Equal(expected, BinarySearcher.Search(array, index, length, value));
        }
    }
}
