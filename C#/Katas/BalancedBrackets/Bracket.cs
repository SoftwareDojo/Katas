using System;
using System.Collections.Generic;

namespace Katas.BalancedBrackets
{
    public class Text
    {
        private readonly string myText;
        private readonly char[] myOpenBrackets = {'(', '{', '['};
        private readonly char[] myCloseBrackets = {')', '}', ']'};
        private const int NotFound = -1; 

        public Text(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentNullException(nameof(text));

            myText = text;
        }

        public bool BracketsBalanced()
        {
            var chars = myText.ToCharArray();
            var textLength = chars.Length;
            if (textLength % 2 != 0) return false;

            var openBrackets = new List<int>();

            for (var i = 0; i < textLength; i++)
            {
                var openBracket = GetOpenBracketIndex(chars[i]);
                if (openBracket != NotFound)
                {
                    openBrackets.Add(openBracket);
                    continue;
                }

                var closeBracket = GetCloseBracketIndex(chars[i]);
                if (closeBracket == NotFound) continue;
                if (openBrackets.Count == 0) return false;

                if (closeBracket != openBrackets[openBrackets.Count - 1])
                {
                    return false;
                }

                openBrackets.RemoveAt(openBrackets.Count - 1);
            }

            return true;
        }

        private int GetOpenBracketIndex(char value)
        {
            return GetBracketIndex(value, myOpenBrackets);
        }

        private int GetCloseBracketIndex(char value)
        {
            return GetBracketIndex(value, myCloseBrackets);
        }

        private int GetBracketIndex(char value, char[] brackets)
        {
            for (var i = 0; i < brackets.Length; i++)
            {
                if (value == brackets[i]) return i;
            }

            return NotFound;
        }
    }
}
