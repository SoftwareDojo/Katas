
namespace Katas.Palindrome
{
    public class PalindromeChecker
    {
        internal bool IsPalindrome(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            if (value.Length == 1) return true;

            var palindrome = Convert(value);

            for (var i = 0; i < palindrome.Length / 2; i++)
            {
                if (palindrome[i] != palindrome[palindrome.Length - 1 - i]) return false;
            }

            return true;
        }

        private string Convert(string value)
        {
            return value.ToLower().Replace(" ", "");
        }
    }
}
