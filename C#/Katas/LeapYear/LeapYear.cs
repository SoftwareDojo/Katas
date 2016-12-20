namespace Katas.LeapYear
{
    public class LeapYear
    {
        public bool IsLeapYear(int year)
        {
            return (year % 4 == 0 || year % 400 == 0);
        }
    }
}
