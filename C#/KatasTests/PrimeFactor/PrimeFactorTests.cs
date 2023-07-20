using System.Linq;
using Xunit;

namespace KatasTests.PrimeFactor
{
    public class PrimeFactorTests
    {
        [Theory]
        [InlineData(1, new int[0])]
        [InlineData(2, new[] { 2 })]
        [InlineData(3, new[] { 3 })]
        [InlineData(4, new[] { 2, 2 })]
        [InlineData(5, new[] { 5 })]
        [InlineData(6, new[] { 2, 3 })]
        [InlineData(7, new[] { 7 })]
        [InlineData(8, new[] { 2, 2, 2 })]
        [InlineData(9, new[] { 3, 3 })]
        public void Generate(int input, int[] expected)
        {
            Assert.True(expected.SequenceEqual(Katas.PrimeFactor.PrimeFactor.Generate(input)));
        }
    }
}
