using System.Collections.Generic;
using Katas;
using Xunit;

namespace KatasTests.CSV
{
    public class CsvReaderTests
    {
        [Fact]
        public void SplitLine_empty()
        {
            Assert.Equal(new[] { string.Empty }, CsvReader.SplitLine(string.Empty));
        }

        [Fact]
        public void SplitLine_remove_whitespaces()
        {
            Assert.Equal(new[] { "A", "B", "C" }, CsvReader.SplitLine("A;B ;C  "));
        }

        [Fact]
        public void SplitFile_empty()
        {
            Assert.Equal(new List<string[]>(), CsvReader.SplitFile(string.Empty));
        }

        [Fact]
        public void SplitFile_remove_empty_lines()
        {
            Assert.Equal([["A", "B", "C", ""], ["", "", ""], ["D", "E", "F"]], CsvReader.SplitFile("A;B;C;\n;;\n\nD;E;F"));
        }
    }
}
