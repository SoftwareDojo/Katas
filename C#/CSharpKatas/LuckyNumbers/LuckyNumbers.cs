using System;

namespace CSharpKatas.LuckyNumbers
{
    public class LuckyNumbers
    {
        public string GetLuckyNumbers(int range)
        {
            return PrintResult(FindLuckyNumbers(range));
        }

        public string GetLuckyPrimeNumbers(int range)
        {
            bool[] numbers = FindLuckyNumbers(range);

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]) continue;
                numbers[i] = !IsPrimeNumber(i+1);
            }

            return PrintResult(numbers);
        }

        private bool[] FindLuckyNumbers(int range)
        {
            if (range < 1) range = 0;
            bool[] numbers = new bool[range];
            int luckyCounter = 2;

            while (luckyCounter < numbers.Length)
            {
                luckyCounter = StrikeOutNumbers(numbers, luckyCounter);
            }

            return numbers;
        }

        private int StrikeOutNumbers(bool[] numbers, int luckyCounter)
        {
            int strikeCounter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]) continue;
                strikeCounter++;
                
                if (strikeCounter == luckyCounter)
                {
                    numbers[i] = true;
                    strikeCounter = 0;
                }
            }

            return GetLuckyCounter(numbers, luckyCounter);
        }

        private int GetLuckyCounter(bool[] numbers, int skip)
        {
            if (skip >= numbers.Length) return numbers.Length;

            for (int i = skip; i < numbers.Length; i++)
            {
                if (!numbers[i]) return i+1;
            }

            return numbers.Length;
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

        private static string PrintResult(bool[] numbers)
        {
            string result = string.Empty;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!numbers[i]) result = result + (i+1) + ",";
            }

            if (!string.IsNullOrEmpty(result)) result = result.Substring(0, result.Length - 1);

            return result;
        }
    }
}
