using System.Collections.Generic;

namespace Katas.PrimeFactor
{
    public class PrimeFactor
    {
        public static IList<int> Generate(int number)
        {
            var primes = new List<int>();

            for (var i = 2; number > 1; i++)
                for (; number % i == 0; number /= i)
                    primes.Add(i);

            return primes.ToArray();
        }
    }
}
