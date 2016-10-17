using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas.RomanNumbers
{
    public class RomanNumbers
    {
        private readonly IDictionary<string, int> m_RomanDigits;
        private readonly IDictionary<int, string> m_ArabicDigits;

        public RomanNumbers()
        {
            m_RomanDigits = new Dictionary<string, int>
            {{"I", 1},{"V", 5},{"X", 10},{"L", 50},{"C", 100},{"D", 500},{"M", 1000}};
            m_ArabicDigits = new Dictionary<int, string>
            { { 1000, "M" }, { 900, "CM" }, { 500, "D" }, { 400, "CD" }, { 100, "C" }, { 90, "XC" }, { 50, "L" }, { 40, "XL" }, { 10, "X" }, { 9, "IX" }, { 5, "V" }, { 4, "IV" }, { 1, "I" } };
        }

        public string FromArabicToRoman(int number)
        {
            string result = string.Empty;
            if (number > 3999) return result;

            foreach (var digit in m_ArabicDigits)
            {
                while (number >= digit.Key)
                {
                    result = result + digit.Value;
                    number = number - digit.Key;
                }
            }

            return result;
        }

        public int FromRomanToDecimal(string romanNumber)
        {
            if (string.IsNullOrEmpty(romanNumber)) throw new ArgumentNullException("romanNumber");
            int decimalResult = 0;

            IList<int> decimalNumbers = new List<int>();
            if (!TryConvertToDecimalDigits(romanNumber, decimalNumbers)) return 0;

            for (int i = 0; i < decimalNumbers.Count; i++)
            {
                if (i + 1 >= decimalNumbers.Count) return decimalResult + decimalNumbers[i];

                // substraction
                if (decimalNumbers[i] < decimalNumbers[i + 1])
                {
                    decimalNumbers[i] = decimalNumbers[i + 1] - decimalNumbers[i];
                    decimalResult = decimalResult + decimalNumbers[i];

                    decimalNumbers.RemoveAt(i + 1);
                }
                // addition
                else
                {
                    decimalResult = decimalResult + decimalNumbers[i];
                }
            }

            return decimalResult;
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
}
