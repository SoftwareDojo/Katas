using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas.RomanNumbers
{
    public static class Convert
    {
        private static readonly IDictionary<string, int> RomanDigits = new Dictionary<string, int>
            {
                { "I", 1 },
                { "V", 5 },
                { "X", 10 },
                { "L", 50 },
                { "C", 100 },
                { "D", 500 },
                { "M", 1000 },
            };

        private static readonly IDictionary<int, string> ArabicDigits = new Dictionary<int, string>
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" },
            };

        public static string FromArabicToRoman(int number)
        {
            var result = string.Empty;
            if (number > 3999) return result;

            foreach (var digit in ArabicDigits)
            {
                while (number >= digit.Key)
                {
                    result += digit.Value;
                    number -= digit.Key;
                }
            }

            return result;
        }

        public static int FromRomanToDecimal(string romanNumber)
        {
            if (string.IsNullOrEmpty(romanNumber)) throw new ArgumentNullException("romanNumber");
            var decimalResult = 0;

            var decimalNumbers = new List<int>();
            if (!TryConvertToDecimalDigits(romanNumber, decimalNumbers)) return 0;

            for (int i = 0; i < decimalNumbers.Count; i++)
            {
                if (i + 1 >= decimalNumbers.Count) return decimalResult + decimalNumbers[i];

                // substraction
                if (decimalNumbers[i] < decimalNumbers[i + 1])
                {
                    decimalNumbers[i] = decimalNumbers[i + 1] - decimalNumbers[i];
                    decimalResult += decimalNumbers[i];

                    decimalNumbers.RemoveAt(i + 1);
                }
                // addition
                else
                {
                    decimalResult += decimalNumbers[i];
                }
            }

            return decimalResult;
        }

        private static bool TryConvertToDecimalDigits(string romanNumber, ICollection<int> numbers)
        {
            foreach (char c in romanNumber)
            {
                var number = c.ToString();
                if (!RomanDigits.ContainsKey(number)) return false;
                var decimalValue = RomanDigits[number];

                if (numbers.Count(n => n == decimalValue) > 3) return false;
                if (!ValidateCombinations(decimalValue, numbers)) return false;

                numbers.Add(decimalValue);
            }

            return !WrongOrder(numbers);
        }

        private static bool ValidateCombinations(int number, ICollection<int> decimalNumbers)
        {
            if (decimalNumbers.Count == 0) return true;
            var last = decimalNumbers.Last();

            if ((number == 5 || number == 50 || number == 500) && last == number) return false;
            if (last >= number) return true;

            if (decimalNumbers.Count(n => n == last) > 1) return false;

            if ((number == 5 || number == 10) && last == 1) return true;
            if ((number == 50 || number == 100) && last == 10) return true;
            if ((number == 500 || number == 1000) && last == 100) return true;

            return false;
        }

        private static bool WrongOrder(ICollection<int> decimalNumbers)
        {
            if (decimalNumbers.Count == 0) return true;

            var prevNumber = 0;
            var prePrevNumber = 0;

            foreach (var number in decimalNumbers)
            {
                if (prevNumber != 0 && prePrevNumber != 0)
                {
                    if (prePrevNumber < number) return true;
                    if (prePrevNumber == number && prevNumber > number) return true;
                }

                prePrevNumber = prevNumber;
                prevNumber = number;
            }

            return false;
        }
    }
}
