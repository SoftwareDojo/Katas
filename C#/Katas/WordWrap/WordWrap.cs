using System;
using System.Collections.Generic;

namespace Katas
{
    public static class Text
    {
        private const string SimpleWhiteSpace = " ";
        private const string NewLine = "\n";

        public static string Wrap(string text, int length)
        {
            return string.Join(string.Empty, Wrap(text.Split(new[] { SimpleWhiteSpace }, StringSplitOptions.RemoveEmptyEntries), length));
        }

        private static IEnumerable<string> Wrap(IEnumerable<string> words, int lineLength)
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

        private static string ReturnNewLineOrWhiteSpace(ref int currentLength, int wordLength, int lineLength)
        {
            if (currentLength + wordLength < lineLength)
            {
                currentLength++;
                return SimpleWhiteSpace;
            }

            currentLength = 0;
            return NewLine;
        }
    }
}
