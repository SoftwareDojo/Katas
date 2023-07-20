using Katas.RomanNumbers;
using Xunit;

namespace KatasTests.RomanNumbers
{
    public class ConvertTest
    {
        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("IIII", 4)]
        [InlineData("V", 5)]
        [InlineData("VIIII", 9)]
        [InlineData("X", 10)]
        [InlineData("XI", 11)]
        [InlineData("XV", 15)]
        [InlineData("XX", 20)]
        [InlineData("XXV", 25)]
        [InlineData("XXX", 30)]
        [InlineData("XXXXIIII", 44)]
        public void TestSimpleConvertion(string value, int expected)
        {
            Assert.Equal(expected, Convert.FromRomanToDecimal(value));
        }

        [Theory]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("XL", 40)]
        [InlineData("XLIV", 44)]
        [InlineData("CMIX", 909)]
        [InlineData("MMCDXIX", 2419)]
        [InlineData("MMCDXCIX", 2499)]
        [InlineData("MMMCMXLIX", 3949)]
        [InlineData("MMMCMXCIX", 3999)]
        public void TestSubtractionConvertion(string value, int expected)
        {
            Assert.Equal(expected, Convert.FromRomanToDecimal(value));
        }

        [Theory]
        [InlineData("abcdef", 0)]
        [InlineData("IIIII", 0)]
        [InlineData("VV", 0)]
        [InlineData("XXXXXX", 0)]
        [InlineData("IC", 0)]
        [InlineData("IIX", 0)]
        [InlineData("IXCM", 0)]
        [InlineData("XVXV", 0)]
        [InlineData("XIXI", 0)]
        [InlineData("CMM", 0)]
        [InlineData("MMCDIXX", 0)]
        public void TestSyntaxErrors(string value, int expected)
        {
            Assert.Equal(expected, Convert.FromRomanToDecimal(value));
        }

        [Theory]
        [InlineData(-1, "")]
        [InlineData(0, "")]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(11, "XI")]
        [InlineData(15, "XV")]
        [InlineData(20, "XX")]
        [InlineData(25, "XXV")]
        [InlineData(30, "XXX")]
        [InlineData(33, "XXXIII")]
        [InlineData(40, "XL")]
        [InlineData(44, "XLIV")]
        [InlineData(909, "CMIX")]
        [InlineData(2419, "MMCDXIX")]
        [InlineData(2499, "MMCDXCIX")]
        [InlineData(3949, "MMMCMXLIX")]
        [InlineData(3999, "MMMCMXCIX")]
        [InlineData(4000, "")]
        public void ConvertArabicToRoman(int value, string expected)
        {
            Assert.Equal(expected, Convert.FromArabicToRoman(value));
        }
    }
}
