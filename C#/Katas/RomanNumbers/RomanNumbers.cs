using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas.RomanNumbers
{
    public class RomanNumbers
    {
        private readonly IDictionary<string, int> m_RomanDigits;

        public RomanNumbers()
        {
            m_RomanDigits = new Dictionary<string, int>
            {{"I", 1},{"V", 5},{"X", 10},{"L", 50},{"C", 100},{"D", 500},{"M", 1000}};
        }


        public int FromRomanToDecimal(string romanNumber)
        {
            if (string.IsNullOrEmpty(romanNumber)) throw new ArgumentNullException("romanNumber");
            int decimalResult = 0;

            IList<int> decimalNumbers = new List<int>();
            if (!TryConvertToDecimalDigits(romanNumber, decimalNumbers)) return 0;

            return 0;
        }

        private bool TryConvertToDecimalDigits(string romanNumber, ICollection<int> numbers)
        {
            foreach (char c in romanNumber)
            {
                string number = c.ToString();
                if (!m_RomanDigits.ContainsKey(number)) return false;
                int decimalValue = m_RomanDigits[number];

                if (numbers.Count(n => n == decimalValue) > 3) return false;
                if (!ValidateCombinations(decimalValue, numbers)) return false;

                numbers.Add(decimalValue);
            }

            return !WrongOrder(numbers);
        }

        private bool ValidateCombinations(int number, ICollection<int> decimalNumbers)
        {
            if (decimalNumbers.Count == 0) return true;
            int last = decimalNumbers.Last();

            if ((number == 5 || number == 50 || number == 500) && last == number) return false;
            if (last >= number) return true;

            if (decimalNumbers.Count(n => n == last) > 1) return false;

            if ((number == 5 || number == 10) && last == 1) return true;
            if ((number == 50 || number == 100) && last == 10) return true;
            if ((number == 500 || number == 1000) && last == 100) return true;

            return false;
        }

        private bool WrongOrder(ICollection<int> decimalNumbers)
        {
            if (decimalNumbers.Count == 0) return true;

            int prevNumber = 0;
            int prePrevNumber = 0;

            foreach (int number in decimalNumbers)
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

    public class Number
    {
        private static readonly Dictionary<string, string> romanDigits = new Dictionary<string, string>
        {
            {"IIIII", "V"}, 
            {"IIII", "IV"}, 
            {"VV", "X"},
            {"VIV", "IX"},
            {"XXXXX", "L"},
            {"XXXX", "XL"},
            {"LL" , "C"},
            {"LXL", "XC"},
            {"CCCCC", "D"},
            {"CCCC", "CD"},
            {"DD", "M"},
            {"DCD", "CM"}
        };

        private static readonly Dictionary<string, int> romanArabicMapping = new Dictionary<string, int>
        {
            {"CM", 900},
            {"M", 1000},
            {"CD", 400},
            {"D", 500},
            {"XC", 90},
            {"C", 100},
            {"XL", 40},
            {"L", 50},
            {"IX", 9},
            {"X", 10},
            {"IV", 4},
            {"V", 5},
            {"I", 1},
        };

        public static string ToRoman(int number)
        {
            if (number < 1) throw new ArgumentException(nameof(number));
            if (number > 3999) throw new ArgumentException(nameof(number));

            var numberAsI = NumberToI(number);

            foreach (var digit in romanDigits)
            {
                numberAsI = numberAsI.Replace(digit.Key, digit.Value);
            }

            return numberAsI;
        }

        public static int ToArabic(string roman)
        {
            roman = roman.ToUpper();
            var number = 0;

            foreach (var map in romanArabicMapping)
            {
                int position;
                while ((position = roman.IndexOf(map.Key)) >= 0)
                {
                    roman = roman.Remove(position, map.Key.Length);
                    number += map.Value;
                }
            }

            if (!string.IsNullOrWhiteSpace(roman)) throw new ArgumentException(nameof(roman));

            return number;
        }

        private static string NumberToI(int number)
        {
            var result = string.Empty;
            for (var i = 0; i < number; i++)
            {
                result += "I";
            }

            return result;
        }
    }
}
