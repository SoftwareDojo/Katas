using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas
{
    public class CsvReader
    {
        public static List<string[]> SplitFile(string file)
        {
            var lines = file.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            return lines.Select(SplitLine).ToList();
        }

        public static string[] SplitLine(string line)
        {
            return line.Split(";", StringSplitOptions.TrimEntries);
        }
    }
}