using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CSharpKataTests.GoldbachsConjecture
{
    [TestFixture]
    public class GoldbachsConjectureTests
    {
        [TestCase(4, "2,2" )]
        [TestCase(6, "3,3")]
        [TestCase(8, "3,5")]
        [TestCase(12, "5,7")]
        public void TwoPrimeCalculationSimple(int value, string expected)
        {
            // arrange
            var gc = new CSharpKatas.GoldbachsConjecture.GoldbachsConjecture();

            // act
            string actual = PrintResult(gc.TwoPrimeCalculation(value));
            
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, "3,7 | 5,5")]
        [TestCase(14, "3,11 | 7,7")]
        [TestCase(16, "3,13 | 5,11")]
        [TestCase(22, "3,19 | 5,17 | 11,11")]
        [TestCase(34, "3,31 | 5,29 | 11,23 | 17,17")]
        [TestCase(48, "5,43 | 7,41 | 11,37 | 17,31 | 19,29")]
        public void TwoPrimeCalculationMultiple(int value, string expected)
        {
            // arrange
            var gc = new CSharpKatas.GoldbachsConjecture.GoldbachsConjecture();

            // act
            string actual = PrintResult(gc.TwoPrimeCalculation(value));

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, "")]
        [TestCase(0, "")]
        [TestCase(1, "")]
        [TestCase(2, "")]
        [TestCase(3, "")]
        [TestCase(5, "")]
        [TestCase(9, "")]
        public void ErrorHandling(int value, string expected)
        {
            // arrange
            var gc = new CSharpKatas.GoldbachsConjecture.GoldbachsConjecture();

            // act
            string actual = PrintResult(gc.TwoPrimeCalculation(value));

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(7, "2,2,3")]
        public void ThreePrimeCalculationSimple(int value, string expected)
        {
            // arrange
            var gc = new CSharpKatas.GoldbachsConjecture.GoldbachsConjecture();

            // act
            string actual = PrintResult(gc.ThreePrimeCalculation(value));

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(9, "2,2,5 | 3,3,3")]
        [TestCase(11, "2,2,7 | 3,3,5")]
        [TestCase(13, "3,3,7 | 3,5,5")]
        [TestCase(15, "2,2,11 | 3,5,7 | 5,5,5")]
        [TestCase(17, "2,2,13 | 3,3,11 | 3,7,7 | 5,5,7")]
        public void ThreePrimeCalculationMultiple(int value, string expected)
        {
            // arrange
            var gc = new CSharpKatas.GoldbachsConjecture.GoldbachsConjecture();

            // act
            string actual = PrintResult(gc.ThreePrimeCalculation(value));

            // assert
            Assert.AreEqual(expected, actual);
        }

        public string PrintResult(IEnumerable<int[]> results)
        {
            string print = string.Empty;
            if (results == null || !results.Any()) return print;

            foreach (int[] result in results)
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
