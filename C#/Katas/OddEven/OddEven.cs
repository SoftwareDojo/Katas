using System;

namespace Katas
{
    public static class OddEven
    {
        private const string Even = "Even";
        private const string Odd = "Odd";

        public static string Convert(int number)
        {
            if (number % 2 == 0) return Even;
            if (IsPrimeNumber(number)) return number.ToString();

            return Odd;
        }

        public static string ConvertRange(int start, int end)
        {
            var result = string.Empty;

            for (int i = start; i <= end; i++)
            {
                result += Convert(i) + " ";
            }

            return result.Trim();
        }

        public static string ConvertWithString(int number)
        {
            string numberTxt = number.ToString();

            if (numberTxt.EndsWith("0") ||
                numberTxt.EndsWith("2") ||
                numberTxt.EndsWith("4") ||
                numberTxt.EndsWith("6") ||
                numberTxt.EndsWith("8"))
                return Even;

            if (IsPrimeNumber(number)) return numberTxt;

            return Odd;
        }

        private static bool IsPrimeNumber(int number)
        {
            if (number == 1) return false;

            for (short i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
