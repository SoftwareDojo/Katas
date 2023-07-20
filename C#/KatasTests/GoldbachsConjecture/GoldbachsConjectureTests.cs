using System.Collections.Generic;
using System.Linq;
using Katas;
using Xunit;

namespace KatasTests
{
    public class GoldbachsConjectureTests
    {
        [Theory]
        [InlineData(4, "2,2")]
        [InlineData(6, "3,3")]
        [InlineData(8, "3,5")]
        [InlineData(12, "5,7")]
        public void TwoPrimeCalculationSimple(int value, string expected)
        {
            Assert.Equal(expected, PrintResult(GoldbachsConjecture.TwoPrimeCalculation(value)));
        }

        [Theory]
        [InlineData(10, "3,7 | 5,5")]
        [InlineData(14, "3,11 | 7,7")]
        [InlineData(16, "3,13 | 5,11")]
        [InlineData(22, "3,19 | 5,17 | 11,11")]
        [InlineData(34, "3,31 | 5,29 | 11,23 | 17,17")]
        [InlineData(48, "5,43 | 7,41 | 11,37 | 17,31 | 19,29")]
        public void TwoPrimeCalculationMultiple(int value, string expected)
        {
            Assert.Equal(expected, PrintResult(GoldbachsConjecture.TwoPrimeCalculation(value)));
        }

        [Theory]
        [InlineData(-1, "")]
        [InlineData(0, "")]
        [InlineData(1, "")]
        [InlineData(2, "")]
        [InlineData(3, "")]
        [InlineData(5, "")]
        [InlineData(9, "")]
        public void ErrorHandling(int value, string expected)
        {
            Assert.Equal(expected, PrintResult(GoldbachsConjecture.TwoPrimeCalculation(value)));
        }

        [Theory]
        [InlineData(7, "2,2,3")]
        public void ThreePrimeCalculationSimple(int value, string expected)
        {
            Assert.Equal(expected, PrintResult(GoldbachsConjecture.ThreePrimeCalculation(value)));
        }

        [Theory]
        [InlineData(9, "2,2,5 | 3,3,3")]
        [InlineData(11, "2,2,7 | 3,3,5")]
        [InlineData(13, "3,3,7 | 3,5,5")]
        [InlineData(15, "2,2,11 | 3,5,7 | 5,5,5")]
        [InlineData(17, "2,2,13 | 3,3,11 | 3,7,7 | 5,5,7")]
        public void ThreePrimeCalculationMultiple(int value, string expected)
        {
            Assert.Equal(expected, PrintResult(GoldbachsConjecture.ThreePrimeCalculation(value)));
        }

        private string PrintResult(IEnumerable<int[]> results)
        {
            var print = string.Empty;
            if (results == null || !results.Any()) return print;

            foreach (var result in results)
            {
                foreach (int num in result)
                {
                    print += num + ",";
                }

                print = print.Substring(0, print.Length - 1) + " | ";
            }

            print = print.Substring(0, print.Length - 3);
            return print;
        }
    }
}
