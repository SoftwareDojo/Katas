using System;
using System.Linq;

namespace Katas.CombinedNumber
{
    public class CombinedNumber
    {
        public string Combine(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return "";

            Array.Sort(numbers, CompareNumbersByLengthAndValue);
            return numbers.Aggregate("", (result, n) => result + n);
        }

        internal int CompareNumbersByLengthAndValue(int x, int y)
        {
            var xDigits = SplitNumber(x.ToString());
            var xDigitsLength = xDigits.Length;
            var yDigits = SplitNumber(y.ToString());
            var yDigitsLength = yDigits.Length;

            for (var i = 0; i < xDigitsLength; i++)
            {
                if (yDigitsLength == i) return 1;

                var result = yDigits[i].CompareTo(xDigits[i]);
                if (result != 0) return result;
            }

            if (xDigitsLength >= yDigitsLength) return 0;

            for (var i = 0; i < xDigitsLength; i++)
            {
                if (xDigits[i] >= yDigits[xDigitsLength]) return -1;
            }

            return 1;
        }

        internal int[] SplitNumber(string number)
        {
            return number.Select(d => int.Parse(d.ToString())).ToArray();
        }
    }
}
