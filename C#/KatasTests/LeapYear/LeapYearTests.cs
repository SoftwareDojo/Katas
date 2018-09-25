using System;
using Katas.LeapYear;
using Xunit;

namespace KatasTests.LeapYear
{
    public class A_year_is_a_leap_year
    {
        [Theory]
        [InlineData(2016)]
        [InlineData(1996)]
        [InlineData(1984)]
        [InlineData(4)]
        public void if_it_is_divisible_by_4_but_not_by_100(int year)
        {
            Assert.True(Year.IsLeapYear(year));
        }

        [Theory]
        [InlineData(400)]
        [InlineData(3200)]
        [InlineData(2000)]
        [InlineData(1600)]
        public void if_it_is_divisible_by_400(int year)
        {
            Assert.True(Year.IsLeapYear(year));
        }
    }

    public class A_year_is_not_a_leap_year
    {
        [Theory]
        [InlineData(2018)]
        [InlineData(2017)]
        [InlineData(1999)]
        [InlineData(1)]
        public void if_it_is_not_divisible_by_4(int year)
        {
            Assert.False(Year.IsLeapYear(year));
        }

        [Theory]
        [InlineData(2100)]
        [InlineData(1900)]
        [InlineData(1800)]
        [InlineData(100)]
        public void if_it_is_divisible_by_100_but_not_by_400(int year)
        {
            Assert.False(Year.IsLeapYear(year));
        }
    }

    public class A_Year_is_not_supported
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-2000)]
        public void if_it_is_negative(int year)
        {
            Assert.Throws<ArgumentException>(() => Year.IsLeapYear(year));
        }
    }
}
