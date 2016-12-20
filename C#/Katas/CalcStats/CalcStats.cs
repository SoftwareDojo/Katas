using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Katas.CalcStats
{
    public class CalcStats
    {
        public string GetStats(string name, int[] values)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (values == null) throw new ArgumentNullException(nameof(values));

            MethodInfo mi = typeof(Enumerable).GetMethod(name, new[] { typeof(IEnumerable<int>) });
            return mi.Invoke(values, new[] { values }).ToString();
        }
    }
}
