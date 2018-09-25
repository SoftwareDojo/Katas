using System;

using Katas.RomanNumbers;

using Xunit;

namespace KatasTests.RomanNumbers
{
    public class RomanNumbersTest
    {
     

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
            // arrange
            var target = new Katas.RomanNumbers.RomanNumbers();

            // act
            int actual = target.FromRomanToDecimal(value);

            // assert
            Assert.Equal(expected, actual);
        }
        
    }

    public class NumberSpec
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
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
        [InlineData(50, "L")]
        [InlineData(90, "XC")]
        [InlineData(99, "XCIX")]
        [InlineData(100, "C")]
        [InlineData(400, "CD")]
        [InlineData(500, "D")]
        [InlineData(900, "CM")]
        [InlineData(909, "CMIX")]
        [InlineData(1000, "M")]
        [InlineData(2419, "MMCDXIX")]
        [InlineData(2499, "MMCDXCIX")]
        [InlineData(3949, "MMMCMXLIX")]
        [InlineData(3999, "MMMCMXCIX")]
        public void convert_to_roman(int number, string expectedRoman)
        {
            Assert.Equal(expectedRoman, Number.ToRoman(number));
        }

        [Theory]
        [InlineData("I", 1)]
        [InlineData("i", 1)]
        [InlineData("II", 2)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("V", 5)]
        [InlineData("IX", 9)]
        [InlineData("X", 10)]
        [InlineData("XI", 11)]
        [InlineData("XV", 15)]
        [InlineData("XX", 20)]
        [InlineData("XXV", 25)]
        [InlineData("XXX", 30)]
        [InlineData("XXXIII", 33)]
        [InlineData("XXXVIII", 38)]
        [InlineData("XL", 40)]
        [InlineData("XLIV", 44)]
        [InlineData("L", 50)]
        [InlineData("XC", 90)]
        [InlineData("C", 100)]
        [InlineData("CD", 400)]
        [InlineData("D", 500)]
        [InlineData("CM", 900)]
        [InlineData("CMIX", 909)]
        [InlineData("M", 1000)]
        [InlineData("MMCDXIX", 2419)]
        [InlineData("MMCDXCIX", 2499)]
        [InlineData("MMMCMXLIX", 3949)]
        [InlineData("MMMCMXCIX", 3999)]
        [InlineData("mmmcmxcix", 3999)]
        public void convert_to_arabic(string roman, int expectedNumber)
        {
            Assert.Equal(expectedNumber, Number.ToArabic(roman));
        }

        public class Numbers_are_not_supported
        {
            [Theory]
            [InlineData(0)]
            [InlineData(-1)]
            public void if_less_than_1(int number)
            {
                Assert.Throws<ArgumentException>(() => Number.ToRoman(number));
            }

            [Theory]
            [InlineData(4000)]
            [InlineData(5055)]
            public void if_greater_than_3999(int number)
            {
                Assert.Throws<ArgumentException>(() => Number.ToRoman(number));
            }

            [Theory]
            [InlineData("Test")]
            [InlineData("I!")]
            public void if_it_contains_unknown_chars(string roman)
            {
                Assert.Throws<ArgumentException>(() => Number.ToArabic(roman));
            }

            //IIII
            //VV
            //XXXX
            //LL
            //CCCC
            //DD
            //MMMM

            //IIV != 3 & != 5 & != 7
            //IIX != 8 & != 10
            //IC != 99
        }
    }
}
