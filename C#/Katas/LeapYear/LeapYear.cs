using System;

namespace Katas.LeapYear
{
    public class Year
    {
        public static bool IsLeapYear(int year)
        {
            if (year < 0) throw new ArgumentException(nameof(year));

            if (year % 400 == 0) return true;
            return year % 4 == 0 && year % 100 != 0;
        }
    }
}
