
namespace Katas.Palindrome
{
    public static class Palindrome
    {
        public static bool IsValid(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase)) return false;
            if (phrase.Length == 1) return true;

            return IsPalindrome(ConvertToLowerAndReplaceWhiteSpaces(phrase));
        }

        private static string ConvertToLowerAndReplaceWhiteSpaces(string value)
        {
            return value.ToLower().Replace(" ", string.Empty);
        }

        private static bool IsPalindrome(string phrase)
        {
            for (var i = 0; i < phrase.Length / 2; i++)
            {
                if (phrase[i] != phrase[phrase.Length - 1 - i]) return false;
            }

            return true;
        }
    }
}
