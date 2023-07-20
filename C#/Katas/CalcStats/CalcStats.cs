using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas
{
    public class CalcStats
    {
        public static object GetStats(string name, int[] values)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (values == null) throw new ArgumentNullException(nameof(values));

            var mi = typeof(Enumerable).GetMethod(name, new[] { typeof(IEnumerable<int>) });
            return mi.Invoke(values, new[] { values });
        }
    }
}
