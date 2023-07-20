namespace Katas.Password
{
    public class PasswordComplexity
    {
        private bool upperLetter;
        private bool lowerLetter;
        private bool digit;
        private bool specialChar;

        public void CheckChar(char c)
        {
            if (char.IsUpper(c)) upperLetter = true;
            if (char.IsLower(c)) lowerLetter = true;
            if (char.IsDigit(c)) digit = true;
            if (!char.IsLetterOrDigit(c)) specialChar = true;
        }

        public bool IsReached()
        {
            return upperLetter && lowerLetter && digit && specialChar;
        }
    }
}
