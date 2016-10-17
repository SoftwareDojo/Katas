using System;

namespace Katas.OddEven
{
    public class OddEven
    {
        private const string s_Even = "Even";
        private const string s_Odd = "Odd";

        public string Convert(int number)
        {
            if (number % 2 == 0) return s_Even;
            if (IsPrimeNumber(number)) return number.ToString();

            return s_Odd;
        }

        public string ConvertRange(int start, int end)
        {
            string result = string.Empty;

            for (int i = start; i <= end; i++)
            {
                result += Convert(i) + " ";
            }

            return result.Trim();
        }

        public string ConvertWithString(int number)
        {
            string numberTxt = number.ToString();

            if (numberTxt.EndsWith("0") ||
                numberTxt.EndsWith("2") ||
                numberTxt.EndsWith("4") ||
                numberTxt.EndsWith("6") ||
                numberTxt.EndsWith("8"))
                return s_Even;

            if (IsPrimeNumber(number)) return numberTxt;

            return s_Odd;
        }

        private bool IsPrimeNumber(int number)
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
