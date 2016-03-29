using NUnit.Framework;

namespace CSharpKataTests.RomanNumbers
{
    [TestFixture]
    public class RomanNumbersTest
    {
        [TestCase("I", 1)]
        [TestCase("II", 2)]
        [TestCase("IIII", 4)]
        [TestCase("V", 5)]
        [TestCase("VIIII", 9)]
        [TestCase("X", 10)]
        [TestCase("XI", 11)]
        [TestCase("XV", 15)]
        [TestCase("XX", 20)]
        [TestCase("XXV", 25)]
        [TestCase("XXX", 30)]
        [TestCase("XXXXIIII", 44)]
        public void TestSimpleConvertion(string value, int expected)
        {
            // arrange
            var target = new CSharpKatas.RomanNumbers.RomanNumbers();

            // act
            int actual = target.FromRomanToDecimal(value);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("IV", 4)]
        [TestCase("IX", 9)]
        [TestCase("XL", 40)]
        [TestCase("XLIV", 44)]
        [TestCase("CMIX", 909)]
        [TestCase("MMCDXIX", 2419)]
        [TestCase("MMCDXCIX", 2499)]
        [TestCase("MMMCMXLIX", 3949)]
        [TestCase("MMMCMXCIX", 3999)]
        public void TestSubtractionConvertion(string value, int expected)
        {
            // arrange
            var target = new CSharpKatas.RomanNumbers.RomanNumbers();

            // act
            int actual = target.FromRomanToDecimal(value);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("abcdef", 0)]
        [TestCase("IIIII", 0)]
        [TestCase("VV", 0)]
        [TestCase("XXXXXX", 0)]
        [TestCase("IC", 0)]
        [TestCase("IIX", 0)]
        [TestCase("IXCM", 0)]
        [TestCase("XVXV", 0)]
        [TestCase("XIXI", 0)]
        [TestCase("CMM", 0)]
        [TestCase("MMCDIXX", 0)]
        public void TestSyntaxErrors(string value, int expected)
        {
            // arrange
            var target = new CSharpKatas.RomanNumbers.RomanNumbers();

            // act
            int actual = target.FromRomanToDecimal(value);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, "")]
        [TestCase(0, "")]
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(11, "XI")]
        [TestCase(15, "XV")]
        [TestCase(20, "XX")]
        [TestCase(25, "XXV")]
        [TestCase(30, "XXX")]
        [TestCase(33, "XXXIII")]
        [TestCase(40, "XL")]
        [TestCase(44, "XLIV")]
        [TestCase(909, "CMIX")]
        [TestCase(2419, "MMCDXIX")]
        [TestCase(2499, "MMCDXCIX")]
        [TestCase(3949, "MMMCMXLIX")]
        [TestCase(3999, "MMMCMXCIX")]
        [TestCase(4000, "")]
        public void ConvertArabicToRoman(int value, string expected)
        {
            // arrange
            var convert = new CSharpKatas.RomanNumbers.RomanNumbers();

            // act
            string actual = convert.FromArabicToRoman(value);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
