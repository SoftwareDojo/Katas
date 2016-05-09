using System;
using System.Collections.Generic;

namespace CSharpKatas.WordWrap
{
    public class WordWrap
    {
        private const string s_WhiteSpace = " ";
        private const string s_NewLine = "\n";

        public string Wrap(string text, int length)
        {
            return string.Join(string.Empty,
                Wrap(text.Split(new[] {s_WhiteSpace}, StringSplitOptions.RemoveEmptyEntries), length));
        }

        private IEnumerable<string> Wrap(IEnumerable<string> words, int lineLength)
        {
            var currentLength = 0;
            foreach (var word in words)
            {
                if (currentLength > 0)
                {
                    yield return ReturnNewLineOrWhiteSpace(ref currentLength, word.Length, lineLength);
                }

                currentLength += word.Length;
                yield return word;
            }
        }

        private string ReturnNewLineOrWhiteSpace(ref int currentLength, int wordLength, int lineLength)
        {
            if (currentLength + wordLength < lineLength)
            {
                currentLength++;
                return s_WhiteSpace;
            }

            currentLength = 0;
            return s_NewLine;
        }
    }
}
