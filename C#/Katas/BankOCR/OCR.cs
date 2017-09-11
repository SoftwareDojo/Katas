using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas.BankOCR
{
    public class OCR
    {
        private readonly List<Character> m_Chars = new Digits();

        public string ReadText(string text)
        {
            var lines = text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            IList<string> results = new List<string>();
            for (int i = 0; i < lines.Length; i += Digits.Height)
            {
                if (i + Digits.Height >= lines.Length) break;
                results.Add(ReadLine(lines, i));
            }

            return string.Join(Environment.NewLine, results);
        }

        private string ReadLine(string[] lines, int lineStart)
        {
            string result = string.Empty;
            for (int i = 0; i < lines[lineStart].Length; i += Digits.Width)
            {
                result += ReadChar(lines, lineStart, i);
            }
            return result;
        }

        private string ReadChar(string[] lines, int lineStart, int charStart)
        {
            IList<Character> results = m_Chars;
            for (int i = 0; i < Digits.Height; i++)
            {
                string charText = lines[i + lineStart].Substring(charStart, Digits.Width);
                results = results.Where(c => c.Lines[i] == charText).ToList();
                if (!results.Any()) break;
            }

            if (results.Count != 1) return string.Empty;
            return results[0].Value;
        }
    }
}
