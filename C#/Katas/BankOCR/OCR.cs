using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas.BankOCR
{
    public class OCR
    {
        public string ReadText(string text)
        {
            var lines = text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            var results = new List<string>();
            for (var i = 0; i < lines.Length; i += Digits.Height)
            {
                if (i + Digits.Height >= lines.Length) break;
                results.Add(ReadLine(lines, i));
            }

            return string.Join(Environment.NewLine, results);
        }

        private string ReadLine(string[] lines, int lineStart)
        {
            var result = string.Empty;
            for (var i = 0; i < lines[lineStart].Length; i += Digits.Width)
            {
                result += ReadChar(lines, lineStart, i);
            }
            return result;
        }

        private string ReadChar(string[] lines, int lineStart, int charStart)
        {
            List<Character> digits = new Digits();
            for (var i = 0; i < Digits.Height; i++)
            {
                var charText = lines[i + lineStart].Substring(charStart, Digits.Width);
                digits = digits.Where(c => c.Lines[i] == charText).ToList();
                if (!digits.Any()) break;
            }

            return digits.Count != 1 ? string.Empty : digits[0].Value;
        }
    }
}
