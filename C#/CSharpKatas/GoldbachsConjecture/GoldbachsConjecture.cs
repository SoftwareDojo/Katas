using System;
using System.Collections.Generic;

namespace CSharpKatas.GoldbachsConjecture
{
    public class GoldbachsConjecture
    {
        public IEnumerable<int[]> TwoPrimeCalculation(int number)
        {
            if (number < 3 || number%2 != 0) return null;
            IList<int[]> results = new List<int[]>();

            for (int i = 1; i <= number/2; i++)
            {
                if (!IsPrimeNumber(i) || !IsPrimeNumber(number - i)) continue;
                
                int[] result = new int[2];
                result[0] = i;
                result[1] = number - i;
                results.Add(result);
            }

            return results;
        }

        public IEnumerable<int[]> ThreePrimeCalculation(int number)
        {
            if (number < 6 || number % 2 == 0) return null;
            IList<int[]> results = new List<int[]>();

            for (int i = 1; i <= number / 2; i++)
            {
                if (!IsPrimeNumber(i)) continue;
                int remain = number - i;
                int startValue = i;

                while (true)
                {
                    bool breakWhile = true;

                    for (int j = startValue; j <= remain / 2; j++)
                    {
                        if (!IsPrimeNumber(j) || !IsPrimeNumber(remain - j)) continue;
                        
                        int[] result = new int[3];
                        result[0] = i;
                        result[1] = j;
                        result[2] = remain - j;
                        results.Add(result);

                        breakWhile = false;
                        startValue = j + 1;
                        break;
                    }
                    if (breakWhile) break;
                }
            }

            return results;
        }

        private bool IsPrimeNumber(int number)
        {
            if (number == 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}

