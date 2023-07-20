using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas
{
    public class LuckyNumbers
    {
        public static string GetLuckyNumbers(int range)
        {
            return string.Join(",", FindLuckyNumbers(range));
        }

        public static string GetLuckyPrimeNumbers(int range)
        {
            var numbers = FindLuckyNumbers(range);
            RemovePrimes(numbers);

            return string.Join(",", numbers);
        }

        private static void RemovePrimes(IList<int> numbers)
        {
            IList<int> toRemove = new List<int>();
            foreach (var number in numbers)
            {
                if (!IsPrimeNumber(number)) toRemove.Add(number);
            }

            foreach (var number in toRemove)
            {
                numbers.Remove(number);
            }
        }

        private static IList<int> FindLuckyNumbers(int range)
        {
            IList<int> numbers = CreateRange(1, range);

            int count = 2;
            while (count != 0 && count <= numbers.Count)
            {
                count = RemoveNumbers(numbers, count);
            }

            return numbers;
        }

        private static int RemoveNumbers(IList<int> numbers, int count)
        {
            IList<int> toRemove = new List<int>();
            int index = -1 + count;

            while (index < numbers.Count)
            {
                toRemove.Add(numbers[index]);
                index += count;
            }

            foreach (var number in toRemove)
            {
                numbers.Remove(number);
            }

            return numbers.FirstOrDefault(n => n > count);
        }

        private static IList<int> CreateRange(int from, int to)
        {
            var numbers = new List<int>();
            for (int i = from; i <= to; i++)
            {
                numbers.Add(i);
            }

            return numbers;
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
